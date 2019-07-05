using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace WasabiUI.Forms.Build.Tools
{
    /// <summary>
    /// The MSBuild task for preprocessing conditional compilation symbols in XAML files.
    /// </summary>
    public class PreprocessXaml : Task
    {
        /// <summary>
        /// The required DefinedSymbols parameter.
        /// </summary>
        [Required]
        public string DefinedSymbols { get; set; }
        /// <summary>
        /// The required EmbeddedXamlResources parameter.
        /// </summary>
        [Required]
        public ITaskItem[] EmbeddedXamlResources { get; set; }
        /// <summary>
        /// The required OutputPath parameter.
        /// </summary>
        [Required]
        public string OutputPath { get; set; }
        /// <summary>
        /// Determines whether ignorable content should be removed.
        /// </summary>
        /// <value>
        /// <c>true</c> if [remove ignorable content]; otherwise, <c>false</c>.
        /// </value>
        public bool RemoveIgnorableContent { get; set; }

        /// <summary>
        /// The output NewEmbeddedXamlResources parameter.
        /// </summary>
        [Output]
        public ITaskItem[] NewEmbeddedXamlResources { get; set; }
        /// <summary>
        /// The output GeneratedFiles parameter.
        /// </summary>
        [Output]
        public ITaskItem[] GeneratedFiles { get; set; }

        /// <summary>
        /// When overridden in a derived class, executes the task.
        /// </summary>
        /// <returns>
        /// true if the task successfully executed; otherwise, false.
        /// </returns>
        public override bool Execute()
        {
            try {
                Log.LogMessage(MessageImportance.High, "WCC > DefinedSymbols: {0}", string.Join(",", DefinedSymbols));

                var preprocessor = new XamlPreprocessor(DefinedSymbols, RemoveIgnorableContent);

                var generatedFiles = new List<ITaskItem>();

                NewEmbeddedXamlResources = ProcessFiles(EmbeddedXamlResources, generatedFiles, preprocessor).ToArray();

                GeneratedFiles = generatedFiles.ToArray();

                return true;
            }
            catch (Exception e) {
                Log.LogErrorFromException(e);

                return false;
            }
        }

        private IEnumerable<ITaskItem> ProcessFiles(ITaskItem[] files, List<ITaskItem> generatedFiles, XamlPreprocessor preprocessor)
        {
            foreach (var file in files) {
                var newFile = ProcessFile(file, preprocessor);
                if (newFile != null) {
                    generatedFiles.Add(newFile);
                    yield return newFile;
                }
                else {
                    yield return file;      // return file as-is
                }
            }
        }

        private ITaskItem ProcessFile(ITaskItem file, XamlPreprocessor preprocessor)
        {
            var sourcePath = file.GetMetadata("FullPath");

            // properly resolve linked xaml
            var targetRelativePath = file.GetMetadata("Link");
            if (string.IsNullOrEmpty(targetRelativePath)) {
                targetRelativePath = file.ItemSpec;
            }

            // if targetRelativePath is still absolute, use file name
            if (Path.IsPathRooted(targetRelativePath)) {
                targetRelativePath = Path.GetFileName(targetRelativePath);
            }

            var targetPath = Path.Combine(OutputPath, targetRelativePath);

            TaskItem result = null;

            // process XAML
            Log.LogMessage(MessageImportance.High, "WCC > Preprocessing {0}", targetRelativePath);
            var start = DateTime.Now;
            if (preprocessor.ProcessXamlFile(sourcePath, targetPath)) {
                // targetPath has been written, create linked item
                result = new TaskItem(targetPath);
                file.CopyMetadataTo(result);
                result.SetMetadata("Link", targetRelativePath);          // this is the trick that makes it all work (replace page with a page link pointing to \obj\debug\preprocessedxaml\*)
            }

            var duration = (DateTime.Now - start).TotalMilliseconds;
            Log.LogMessage(MessageImportance.Normal, "WCC > Preprocess completed in {0}ms, {1} has {2}changed", duration, targetRelativePath, result == null ? "not " : "");

            return result;
        }
    }
}
