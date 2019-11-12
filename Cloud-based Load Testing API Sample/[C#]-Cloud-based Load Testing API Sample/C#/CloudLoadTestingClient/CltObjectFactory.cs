namespace CloudLoadTestingClient
{
    public class CltObjectFactory
    {
        /// <summary>
        /// Creates a default test run object that can be used to start a test run on the CLT service.
        /// </summary>
        /// <param name="runName"></param>
        /// <returns></returns>
        public static TestRun CreateTestRunObject(string runName)
        {
            return new TestRun
            {
                Description = "loadtest",
                Name = runName,
            };
        }

        /// <summary>
        /// Creates a default test settings object that can be used to specify test settings and setup and cleanup commands for a CLT test run.
        /// </summary>
        /// <param name="hostProcessPlatform"></param>
        /// <param name="setupCommand"></param>
        /// <param name="cleanupCommand"></param>
        /// <returns></returns>
        public static TestSettings CreateTestSettingsObject(ProcessorArchitecture hostProcessPlatform = ProcessorArchitecture.X86, string setupCommand = "", string cleanupCommand = "")
        {
            return new TestSettings
            {
                HostProcessPlatform = hostProcessPlatform,
                SetupCommand = setupCommand,
                CleanupCommand = cleanupCommand,
            };
        }
    }
}
