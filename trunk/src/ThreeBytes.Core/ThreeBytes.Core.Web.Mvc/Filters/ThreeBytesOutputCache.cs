using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI;

namespace ThreeBytes.Core.Web.Mvc.Filters
{
    // Credit to http://thenullreference.com/blog/fixing-the-asp-net-mvc-3-outputcacheattribute-for-partial-views-to-honor-some-web-config-settings/
    [SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "Unsealed so that subclassed types can set properties in the default constructor.")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ThreeBytesOutputCache : ActionFilterAttribute, IExceptionFilter
    {
        private OutputCacheParameters cacheSettings = new OutputCacheParameters { VaryByParam = "*" };
        private const string cacheKeyPrefix = "_MvcChildActionCache_";
        private static ObjectCache childActionCache;
        private Func<ObjectCache> childActionCacheThunk = () => ChildActionCache;
        private static object childActionFilterFinishCallbackKey = new object();
        private bool locationWasSet;
        private bool noStoreWasSet;
 
        public ThreeBytesOutputCache()
        {
        }

        internal ThreeBytesOutputCache(ObjectCache childActionCache)
        {
            childActionCacheThunk = () => childActionCache;
        }
 
        public string CacheProfile
        {
            get
            {
                return cacheSettings.CacheProfile ?? String.Empty;
            }
            set
            {
                cacheSettings.CacheProfile = value;
            }
        }
 
        internal OutputCacheParameters CacheSettings
        {
            get
            {
                return cacheSettings;
            }
        }
 
        public static ObjectCache ChildActionCache
        {
            get
            {
                return childActionCache ?? MemoryCache.Default;
            }
            set
            {
                childActionCache = value;
            }
        }
 
        private ObjectCache ChildActionCacheInternal
        {
            get
            {
                return childActionCacheThunk();
            }
        }
 
        public int Duration
        {
            get
            {
                return cacheSettings.Duration;
            }
            set
            {
                cacheSettings.Duration = value;
            }
        }
 
        public OutputCacheLocation Location
        {
            get
            {
                return cacheSettings.Location;
            }
            set
            {
                cacheSettings.Location = value;
                locationWasSet = true;
            }
        }
 
        public bool NoStore
        {
            get
            {
                return cacheSettings.NoStore;
            }
            set
            {
                cacheSettings.NoStore = value;
                noStoreWasSet = true;
            }
        }
 
        public string SqlDependency
        {
            get
            {
                return cacheSettings.SqlDependency ?? String.Empty;
            }
            set
            {
                cacheSettings.SqlDependency = value;
            }
        }
 
        public string VaryByContentEncoding
        {
            get
            {
                return cacheSettings.VaryByContentEncoding ?? String.Empty;
            }
            set
            {
                cacheSettings.VaryByContentEncoding = value;
            }
        }
 
        public string VaryByCustom
        {
            get
            {
                return cacheSettings.VaryByCustom ?? String.Empty;
            }
            set
            {
                cacheSettings.VaryByCustom = value;
            }
        }
 
        public string VaryByHeader
        {
            get
            {
                return cacheSettings.VaryByHeader ?? String.Empty;
            }
            set
            {
                cacheSettings.VaryByHeader = value;
            }
        }
 
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Param", Justification = "Matches the @ OutputCache page directive.")]
        public string VaryByParam
        {
            get
            {
                return cacheSettings.VaryByParam ?? String.Empty;
            }
            set
            {
                cacheSettings.VaryByParam = value;
            }
        }
 
        private static void ClearChildActionFilterFinishCallback(ControllerContext controllerContext)
        {
            controllerContext.HttpContext.Items.Remove(childActionFilterFinishCallbackKey);
        }
 
        private static void CompleteChildAction(ControllerContext filterContext, bool wasException)
        {
            Action<bool> callback = GetChildActionFilterFinishCallback(filterContext);
 
            if (callback != null)
            {
                ClearChildActionFilterFinishCallback(filterContext);
                callback(wasException);
            }
        }
 
        private static Action<bool> GetChildActionFilterFinishCallback(ControllerContext controllerContext)
        {
            return controllerContext.HttpContext.Items[childActionFilterFinishCallbackKey] as Action<bool>;
        }
 
        internal string GetChildActionUniqueId(ActionExecutingContext filterContext)
        {
            StringBuilder uniqueIdBuilder = new StringBuilder();
 
            // Start with a prefix, presuming that we share the cache with other users
            uniqueIdBuilder.Append(cacheKeyPrefix);
 
            // Unique ID of the action description
            uniqueIdBuilder.Append(filterContext.ActionDescriptor.UniqueId);
 
            // Unique ID from the VaryByCustom settings, if any
            uniqueIdBuilder.Append(MyDescriptorUtil.CreateUniqueId(VaryByCustom));
            if (!String.IsNullOrEmpty(VaryByCustom))
            {
                string varyByCustomResult = filterContext.HttpContext.ApplicationInstance.GetVaryByCustomString(HttpContext.Current, VaryByCustom);
                uniqueIdBuilder.Append(varyByCustomResult);
            }
 
            // Unique ID from the VaryByParam settings, if any
            uniqueIdBuilder.Append(GetUniqueIdFromActionParameters(filterContext, SplitVaryByParam(VaryByParam)));
 
            // The key is typically too long to be useful, so we use a cryptographic hash
            // as the actual key (better randomization and key distribution, so small vary
            // values will generate dramtically different keys).
            using (SHA256 sha = SHA256.Create())
            {
                return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(uniqueIdBuilder.ToString())));
            }
        }
 
        private static string GetUniqueIdFromActionParameters(ActionExecutingContext filterContext, IEnumerable<string> keys)
        {
            // Generate a unique ID of normalized key names + key values
            var keyValues = new Dictionary<string, object>(filterContext.ActionParameters, StringComparer.OrdinalIgnoreCase);
            keys = (keys ?? keyValues.Keys).Select(key => key.ToUpperInvariant())
                                           .OrderBy(key => key, StringComparer.Ordinal);
 
            return MyDescriptorUtil.CreateUniqueId(keys.Concat(keys.Select(key => keyValues.ContainsKey(key) ? keyValues[key] : null)));
        }
 
        public static bool IsChildActionCacheActive(ControllerContext controllerContext)
        {
            return GetChildActionFilterFinishCallback(controllerContext) != null;
        }
 
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
 
            // Complete the request if the child action threw an exception
            if (filterContext.IsChildAction && filterContext.Exception != null)
            {
                CompleteChildAction(filterContext, wasException: true);
            }
        }
 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            var configSection = (OutputCacheSection)ConfigurationManager.GetSection("system.web/caching/outputCache");
 
            if (configSection.EnableOutputCache)
            {
 
                if (filterContext.IsChildAction)
                {
                  
                    ValidateChildActionConfiguration();
 
                    // Already actively being captured? (i.e., cached child action inside of cached child action)
                    // Realistically, this needs write substitution to do properly (including things like authentication)
                    if (GetChildActionFilterFinishCallback(filterContext) != null)
                    {
                        throw new InvalidOperationException("Cannot nest child cache");
                    }
 
                    // Already cached?
                    string uniqueId = GetChildActionUniqueId(filterContext);
                    string cachedValue = ChildActionCacheInternal.Get(uniqueId) as string;
                    if (cachedValue != null)
                    {
                        filterContext.Result = new ContentResult() { Content = cachedValue };
                        return;
                    }
 
                    // Swap in a new TextWriter so we can capture the output
                    StringWriter cachingWriter = new StringWriter(CultureInfo.InvariantCulture);
                    TextWriter originalWriter = filterContext.HttpContext.Response.Output;
                    filterContext.HttpContext.Response.Output = cachingWriter;
 
                    // Set a finish callback to clean up
                    SetChildActionFilterFinishCallback(filterContext, wasException =>
                    {
                        // Restore original writer
                        filterContext.HttpContext.Response.Output = originalWriter;
 
                        // Grab output and write it
                        string capturedText = cachingWriter.ToString();
                        filterContext.HttpContext.Response.Write(capturedText);
 
                        // Only cache output if this wasn't an error
                        if (!wasException)
                        {
                            ChildActionCacheInternal.Add(uniqueId, capturedText, DateTimeOffset.UtcNow.AddSeconds(Duration));
                        }
                    });
                }
            }
        }
 
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
 
            if (filterContext.IsChildAction)
            {
                CompleteChildAction(filterContext, wasException: true);
            }
        }
 
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
 
            if (!filterContext.IsChildAction)
            {
                // we need to call ProcessRequest() since there's no other way to set the Page.Response intrinsic
                using (OutputCachedPage page = new OutputCachedPage(cacheSettings))
                {
                    page.ProcessRequest(HttpContext.Current);
                }
            }
        }
 
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
 
            if (filterContext.IsChildAction)
            {
                CompleteChildAction(filterContext, wasException: filterContext.Exception != null);
            }
        }
 
        private static void SetChildActionFilterFinishCallback(ControllerContext controllerContext, Action<bool> callback)
        {
            controllerContext.HttpContext.Items[childActionFilterFinishCallbackKey] = callback;
        }
 
        private static IEnumerable<string> SplitVaryByParam(string varyByParam)
        {
            if (String.Equals(varyByParam, "none", StringComparison.OrdinalIgnoreCase))
            {  // Vary by nothing
                return Enumerable.Empty<string>();
            }
 
            if (String.Equals(varyByParam, "*", StringComparison.OrdinalIgnoreCase))
            {  // Vary by everything
                return null;
            }
 
            return from part in varyByParam.Split(';')  // Vary by specific parameters
                   let trimmed = part.Trim()
                   where !String.IsNullOrEmpty(trimmed)
                   select trimmed;
        }
 
        private void ValidateChildActionConfiguration()
        {
 
            if (!String.IsNullOrWhiteSpace(CacheProfile))
            {
                var cacheSettings =
                    (OutputCacheSettingsSection)
                    ConfigurationManager.GetSection("system.web/caching/outputCacheSettings");
                if ((cacheSettings != null) && (cacheSettings.OutputCacheProfiles.Count > 0))
                {
                    var profile = cacheSettings.OutputCacheProfiles[CacheProfile];
                    if (profile == null)
                    {
                        throw new HttpException("Cache Profile Not found");
                    }
                    if (!string.IsNullOrWhiteSpace(profile.SqlDependency) ||
                        !String.IsNullOrWhiteSpace(profile.VaryByContentEncoding) ||
                        !string.IsNullOrWhiteSpace(profile.VaryByControl) ||
                        !String.IsNullOrWhiteSpace(profile.VaryByCustom) || profile.NoStore)
                    {
                        throw new InvalidOperationException("OutputCacheAttribute ChildAction UnsupportedSetting");
                    }
                    //overwrite the parameters
                    VaryByParam = profile.VaryByParam;
                    Duration = profile.Duration;
                }
                else
                {
                    throw new HttpException("Cache settings and profile not found");
                }
            }
 
            if (!String.IsNullOrWhiteSpace(SqlDependency) ||
                !String.IsNullOrWhiteSpace(VaryByContentEncoding) ||
                !String.IsNullOrWhiteSpace(VaryByHeader) ||
                locationWasSet || noStoreWasSet)
            {
                throw new InvalidOperationException("OutputCacheAttribute ChildAction UnsupportedSetting");
            }
 
            if (Duration <= 0)
            {
                throw new InvalidOperationException("Invalid Duration");
            }
 
            if (String.IsNullOrWhiteSpace(VaryByParam))
            {
                throw new InvalidOperationException("Invalid vary by param");
            }
 
 
        }
 
        private sealed class OutputCachedPage : Page
        {
            private OutputCacheParameters _cacheSettings;
 
            public OutputCachedPage(OutputCacheParameters cacheSettings)
            {
                // Tracing requires Page IDs to be unique.
                ID = Guid.NewGuid().ToString();
                _cacheSettings = cacheSettings;
            }
 
            protected override void FrameworkInitialize()
            {
                // when you put the <%@ OutputCache %> directive on a page, the generated code calls InitOutputCache() from here
                base.FrameworkInitialize();
                InitOutputCache(_cacheSettings);
            }
        }
    }
 
    internal static class MyDescriptorUtil
    {
 
        private static void AppendPartToUniqueIdBuilder(StringBuilder builder, object part)
        {
            if (part == null)
            {
                builder.Append("[-1]");
            }
            else
            {
                string partString = Convert.ToString(part, CultureInfo.InvariantCulture);
                builder.AppendFormat("[{0}]{1}", partString.Length, partString);
            }
        }
 
        public static string CreateUniqueId(params object[] parts)
        {
            return CreateUniqueId((IEnumerable<object>)parts);
        }
 
        public static string CreateUniqueId(IEnumerable<object> parts)
        {
            // returns a unique string made up of the pieces passed in
            StringBuilder builder = new StringBuilder();
            foreach (object part in parts)
            {
                // We can special-case certain part types
 
                MemberInfo memberInfo = part as MemberInfo;
                if (memberInfo != null)
                {
                    AppendPartToUniqueIdBuilder(builder, memberInfo.Module.ModuleVersionId);
                    AppendPartToUniqueIdBuilder(builder, memberInfo.MetadataToken);
                    continue;
                }
 
                ICustomUniquelyIdentifiable uniquelyIdentifiable = part as ICustomUniquelyIdentifiable;
                if (uniquelyIdentifiable != null)
                {
                    AppendPartToUniqueIdBuilder(builder, uniquelyIdentifiable.UniqueId);
                    continue;
                }
 
                AppendPartToUniqueIdBuilder(builder, part);
            }
 
            return builder.ToString();
        }
 
        public static TDescriptor[] LazilyFetchOrCreateDescriptors<TReflection, TDescriptor>(ref TDescriptor[] cacheLocation, Func<TReflection[]> initializer, Func<TReflection, TDescriptor> converter)
        {
            // did we already calculate this once?
            TDescriptor[] existingCache = Interlocked.CompareExchange(ref cacheLocation, null, null);
            if (existingCache != null)
            {
                return existingCache;
            }
 
            TReflection[] memberInfos = initializer();
            TDescriptor[] descriptors = memberInfos.Select(converter).Where(descriptor => descriptor != null).ToArray();
            TDescriptor[] updatedCache = Interlocked.CompareExchange(ref cacheLocation, descriptors, null);
            return updatedCache ?? descriptors;
        }
 
    }
 
    internal interface ICustomUniquelyIdentifiable
    {
        string UniqueId { get; }
    }
}
