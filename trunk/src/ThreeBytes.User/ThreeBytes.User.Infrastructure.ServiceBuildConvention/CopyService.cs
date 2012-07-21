using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace ThreeBytes.User.Infrastructure.ServiceBuildConvention
{
    public class CopyService : Task
    {
        [Required]
        public string Configuration { get; set; }

        [Required]
        public string[] AC { get; set; }

        public string BackendFolder { get; set; }
        public string JobFolder { get; set; }
        public string FrontendFolder { get; set; }

        [Required]
        public string Prefix { get; set; }

        public override bool Execute()
        {
            var basePath = Environment.CurrentDirectory;
            var suffixes = new[] { "Backend", "Configuration.Abstract", "Configuration.Concrete", "Data.Abstract", "Data.Concrete", "Entities", "Entities.Mappings", "Frontend", "Messages", "Resources", "Jobs", "Service.Abstract", "Service.Concrete", "Validations.Abstract", "Validations.Concrete" };

            foreach (var ac in AC)
            {
                var acPath = basePath + Path.DirectorySeparatorChar + Prefix + "." + ac;

                foreach (var projectSuffix in suffixes)
                {
                    var projectPath = string.Format("{0}.{1}{2}bin{3}{4}",
                                                    acPath,
                                                    projectSuffix,
                                                    Path.DirectorySeparatorChar,
                                                    Path.DirectorySeparatorChar,
                                                    Configuration);

                    Log.LogCommandLine(MessageImportance.Normal, "Checking for " + projectPath);

                    var files = BuildSourceFiles(projectPath, Prefix + "." + ac + "." + projectSuffix + ".*");

                    if (files.Length == 0)
                    {
                        Log.LogWarning("Could not find {0}.", projectPath);
                        continue;
                    }

                    foreach (var destination in IterateDestinationsFor(ac, projectSuffix))
                    {
                        var copy = new Microsoft.Build.Tasks.Copy();
                        copy.BuildEngine = this.BuildEngine;
                        copy.SourceFiles = files;
                        copy.DestinationFiles = RebaseFilepath(projectPath, destination, files);
                        copy.Retries = 3;
                        copy.RetryDelayMilliseconds = 100;
                        copy.Execute();
                    }
                }
            }

            return true;
        }

        private ITaskItem[] RebaseFilepath(string sourcePrefix, string destinationPrefix, IEnumerable<ITaskItem> files)
        {
            var length = sourcePrefix.Length + 1; // escaped slash
            var ret = new List<TaskItem>();

            foreach (var file in files)
            {
                var name = Path.Combine(destinationPrefix, file.ItemSpec.Substring(length));
                ret.Add(new TaskItem(name));
            }

            return ret.ToArray();
        }

        private IEnumerable<string> IterateDestinationsFor(string ac, string projectSuffix)
        {
            switch (projectSuffix)
            {
                case "Configuration.Abstract":
                case "Configuration.Concrete":
                case "Data.Abstract":
                case "Data.Concrete":
                case "Entities":
                case "Entities.Mappings":
                case "Entities.Resources":
                case "Resources":
                case "Service.Abstract":
                case "Service.Concrete":
                case "Validations.Abstract":
                case "Validations.Concrete":
                    if (!string.IsNullOrEmpty(FrontendFolder))
                        yield return FrontendFolder;
                    if (!string.IsNullOrEmpty(BackendFolder))
                        yield return BackendFolder;
                    if (!string.IsNullOrEmpty(JobFolder))
                        yield return JobFolder;
                    break;
                case "Messages":
                    if (!string.IsNullOrEmpty(FrontendFolder))
                        yield return FrontendFolder;
                    if (!string.IsNullOrEmpty(BackendFolder))
                        yield return BackendFolder;
                    break;
                case "Frontend":
                    if (!string.IsNullOrEmpty(FrontendFolder))
                        yield return FrontendFolder;
                    break;
                case "Backend":
                    if (!string.IsNullOrEmpty(BackendFolder))
                        yield return BackendFolder;
                    break;
                case "Jobs":
                    if (!string.IsNullOrEmpty(JobFolder))
                        yield return JobFolder;
                    break;
                default:
                    throw new Exception("Unknown suffix " + projectSuffix);
            }
        }

        private ITaskItem[] BuildSourceFiles(string directory, string mask)
        {
            var ret = new List<ITaskItem>();

            if (!Directory.Exists(directory))
            {
                return new ITaskItem[] { };
            }

            var dir = new DirectoryInfo(directory);

            foreach (var file in dir.EnumerateFiles(mask, SearchOption.AllDirectories))
            {
                ret.Add(new TaskItem(file.FullName));
            }

            return ret.ToArray();
        }
    }
}
