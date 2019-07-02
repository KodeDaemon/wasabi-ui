using System;
using System.Globalization;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace WasabiUI.Forms.Build.Tools
{
    /// <inheritdoc />
    /// <summary>
    /// <b>Valid TaskActions are:</b>
    /// <para><i>Get</i> (<b>Optional: </b> Variable <b>Optional: </b>Target <b>Output: </b> Value)</para>
    /// <para><i>Set</i> (<b>Optional: </b> Variable, Value <b>Optional: </b>Target)</para>
    /// </summary>
    /// <example>
    /// <code lang="xml"><![CDATA[
    /// <Project ToolsVersion="4.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003" InitialTargets="SetWccDefinitions">
    ///     <Target Name="SetWccDefinitions">
    ///         <!-- Set the default variable (WCC_DEFINITIONS) in the default target (User) to the value of "__ANDROID__" -->
    ///         <VariableConstants TaskAction="Set" Value="__ANDROID__" />
    ///         <!-- Get the Environment Variable using the defaults -->
    ///         <VariableConstants TaskAction="Get">
    ///             <Output PropertyName="EnvValue" TaskParameter="Value"/>
    ///         </VariableConstants>
    ///         <Message Text="Get: $(EnvValue)"/>
    ///         <!-- Set a new Environment Variable in the Process target to multiple values-->
    ///         <VariableConstants TaskAction="Set" Variable="ANewEnvSample" Value="bddd;xyz" Target="Process"/>
    ///         <!-- Get the Environment Variable -->
    ///         <VariableConstants TaskAction="Get" Variable="ANewEnvSample" Target="Process">
    ///             <Output PropertyName="EnvValue" TaskParameter="Value"/>
    ///         </VariableConstants>
    ///         <Message Text="Get: $(EnvValue)"/>
    ///     </Target>
    ///     <Target Name="CleanWccDefinitions" BeforeTargets="Clean">
    ///         <!-- Clear the default Environment Variable. -->
    ///         <VariableConstants TaskAction="Set" Value=""/>
    ///         <!-- Get the Environment Variable -->
    ///         <VariableConstants TaskAction="Get" Variable="ANewEnvSample">
    ///             <Output PropertyName="EnvValue" TaskParameter="Value"/>
    ///         </VariableConstants>
    ///         <Message Text="Get: $(EnvValue)"/>
    ///     </Target>
    /// </Project>
    /// ]]></code>    
    /// </example>
    public class VariableConstants : Task
    {
        private const string SetTaskAction = "Set";
        private const string GetTaskAction = "Get";
        private const string DefaultKey = "WCC_DEFINITIONS";

        private EnvironmentVariableTarget _target = EnvironmentVariableTarget.User;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public VariableConstants()
        {
            Variable = DefaultKey;
        }

        /// <summary>
        /// Gets or sets the value. May be a string array for Get. If Value is not passed or empty for Set, the environment variable is deleted.
        /// </summary>
        [Output]
        public string[] Value { get; set; }

        /// <summary>
        /// The name of the Environment Variable to get or set.
        /// </summary>
        public string Variable { get; set; }

        /// <summary>
        /// Sets the TaskAction.
        /// </summary>
        public virtual string TaskAction { get; set; }

        /// <summary>
        /// Set to true to log the full Exception Stack to the console.
        /// </summary>
        public bool LogExceptionStack { get; set; }

        /// <summary>
        /// Set to true to suppress all Message logging by tasks. Errors and Warnings are not affected.
        /// </summary>
        public bool SuppressTaskMessages { get; set; }

        /// <summary>
        /// Machine, Process or User. Defaults to Process
        /// </summary>
        public string Target
        {
            get => _target.ToString();

            set
            {
                if (Enum.IsDefined(typeof(EnvironmentVariableTarget), value))
                {
                    _target = (EnvironmentVariableTarget)Enum.Parse(typeof(EnvironmentVariableTarget), value);
                }
                else
                {
                    Log.LogError(string.Format(CultureInfo.CurrentCulture, "The value '{0}' is not in the EnvironmentVariableTarget Enum. Use Process, User or Machine.", value));
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public sealed override bool Execute()
        {
            DetermineLogging();
            try
            {
                InternalExecute();
                return !Log.HasLoggedErrors;
            }
            catch (Exception ex)
            {
                GetExceptionLevel();
                Log.LogErrorFromException(ex, LogExceptionStack, true, null);
                return !Log.HasLoggedErrors;
            }
        }

        /// <summary>
        /// Performs the action of this task.
        /// </summary>
        private void InternalExecute()
        {
            switch (TaskAction)
            {
                case GetTaskAction:
                    Get();
                    break;
                case SetTaskAction:
                    Set();
                    break;
                default:
                    Log.LogError(string.Format(CultureInfo.CurrentCulture, "Invalid TaskAction passed: {0}", TaskAction));
                    return;
            }
        }

        /// <summary>
        /// Sets this instance.
        /// </summary>
        private void Set()
        {
            if (Value == null)
            {
                Log.LogMessage(MessageImportance.High, string.Format(CultureInfo.CurrentCulture, "WCC > Removing Environment Variable: \"{0}\" for target \"{1}\".", Variable, _target));
                Environment.SetEnvironmentVariable(Variable, string.Empty, _target);
            }
            else
            {
                var s = new StringBuilder(Value.Length);
                foreach (var val in Value)
                {
                    s.Append(val + ";");
                }

                var newValue = s.ToString();
                newValue = newValue.Remove(newValue.Length - 1, 1);
                Log.LogMessage(MessageImportance.High, string.Format(CultureInfo.CurrentCulture, "WCC > Setting Environment Variable: \"{0}\" for target \"{1}\" to \"{2}\".", Variable, _target, newValue));
                Environment.SetEnvironmentVariable(Variable, newValue, _target);
            }
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        private void Get()
        {
            Log.LogMessage(MessageImportance.High, string.Format(CultureInfo.CurrentCulture, "WCC > Getting Environment Variable: \"{0}\" for target: \"{1}\"", Variable, _target));

            var temp = Environment.GetEnvironmentVariable(Variable, _target);
            if (!string.IsNullOrEmpty(temp))
            {
                Value = temp.Split(';');
            }
            else
            {
                Log.LogMessage(MessageImportance.High, string.Format(CultureInfo.CurrentCulture, "WCC > The Environment Variable was not found: \"{0}\" for target: \"{1}\"", Variable, _target));
            }

        }

        private void GetExceptionLevel()
        {
            var s = Environment.GetEnvironmentVariable("LogExceptionStack", EnvironmentVariableTarget.Machine);

            if (!string.IsNullOrEmpty(s))
            {
                LogExceptionStack = Convert.ToBoolean(s, CultureInfo.CurrentCulture);
            }
        }

        private void DetermineLogging()
        {
            var s = Environment.GetEnvironmentVariable("SuppressTaskMessages", EnvironmentVariableTarget.Machine);

            if (!string.IsNullOrEmpty(s))
            {
                SuppressTaskMessages = Convert.ToBoolean(s, CultureInfo.CurrentCulture);
            }
        }
    }
}
