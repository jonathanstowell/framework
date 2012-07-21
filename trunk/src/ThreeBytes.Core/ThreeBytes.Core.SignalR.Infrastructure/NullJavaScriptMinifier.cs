using SignalR.Infrastructure;

namespace ThreeBytes.Core.SignalR.Infrastructure
{
    public class NullJavaScriptMinifier : IJavaScriptMinifier
    {
        public static readonly NullJavaScriptMinifier Instance = new NullJavaScriptMinifier();

        public string Minify(string source)
        {
            return source;
        }
    }
}
