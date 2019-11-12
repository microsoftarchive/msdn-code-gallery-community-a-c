using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CloudLoadTestingClient.WebApiModels;

namespace CloudLoadTestingClient
{
    class CltOperations
    {
        /// <summary>
        /// Creates a test run, uploads the load test sources and starts the run. 
        /// </summary>
        /// <param name="localDirectory">the directory containing the test sources</param>
        /// <param name="loadTestFileName">the loadtest file name of the loadtest</param>
        /// <returns></returns> 
        public static TestRun CreateAndStartRun(string localDirectory, string loadTestFileName)
        {
            //check for extension
            if (!Path.HasExtension(loadTestFileName))
            {
                loadTestFileName = string.Concat(loadTestFileName, ".loadtest");
                Logger.LogMessage("Appending .loadtest to the given loadtest name");
            }
            //check if load test file exists in test drop
            if (!File.Exists(Path.Combine(localDirectory, loadTestFileName)))
            {
                Logger.LogMessage(string.Format(CultureInfo.CurrentCulture, "LoadTest file not found in the test drop. Please ensure that the loadtest file is present in the drop and the correct name is provided. Also please ensure the test drop has all binaries and other files needed to run your test."));
                return null;
            }
            // Create test drop
            Logger.LogMessage("Creating TestDrop....");
            var testDrop = CltWebApi.CreateTestDrop();
            Logger.LogMessage("Done. TestDropId = {0}", testDrop.Id);
            
            // Upload test files
            Logger.LogMessage("Uploading test sources....");
            CltUploadDownloadHelper.Upload(localDirectory, testDrop);
            Logger.LogMessage("Done");

            TestRun testRun = CltObjectFactory.CreateTestRunObject(loadTestFileName);
            var testDropRef = new TestDropRef();
            testRun.TestDrop = testDropRef;
            testRun.TestDrop.Id = testDrop.Id;
            testRun.TestSettings = CltObjectFactory.CreateTestSettingsObject();

            // Create testrun
            Logger.LogMessage("Creating test run....");
            var createdTestRun = CltWebApi.CreateTestRun(testRun);
            Logger.LogMessage("Done.");

            // Start test run
            Logger.LogMessage("Starting test run....");
            CltWebApi.StartTestRun(createdTestRun.Id);
            Logger.LogMessage("Done");
            
            // Print test run state
            return CltWebApi.GetTestRun(createdTestRun.Id);
        }

        /// <summary>
        /// Gets the test run specified by the runid
        /// </summary>
        /// <param name="testRunId"></param>
        /// <returns></returns>
        public static TestRun GetTestRun(string testRunId)
        {
            // Get test run and show status
            return CltWebApi.GetTestRun(testRunId);
        }

        /// <summary>
        /// Gets the list of testruns from the service (optional query params are allowed)
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TestRun> GetTestRuns(string queryParam= null, string value = null)
        {
            // Get test run and show status
            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(queryParam))
            {
                if (queryParam.Equals("name") && !value.Contains(".loadtest"))
                {
                  value = string.Concat(value, ".loadtest");
                 Logger.LogMessage("Appending .loadtest to the given loadtest name for filtering");
                }
            }
            return CltWebApi.GetTestRuns(queryParam, value);
        }

        /// <summary>
        /// Downloads the result for the given test run, decompresses it to an ltrar file
        /// </summary>
        /// <param name="testRunId"></param>
        internal static void DownloadResult(string testRunId)
        {
            var testResults = CltWebApi.GetTestRunResults(testRunId);
            if (string.IsNullOrWhiteSpace(testResults.ResultsUrl))
            {
                Logger.LogMessage("No result available for run " + testRunId);
            }
            else
            {
                Logger.LogMessage("Downloading result file from uri: {0}", testResults.ResultsUrl);
                var resultFilePath = CltUploadDownloadHelper.DownloadResult(testResults.ResultsUrl);
                Logger.LogMessage("File location: {0}", resultFilePath);
                Console.WriteLine("Decompressing result.");
                var ltrarFilePath = CltUploadDownloadHelper.DecompressResult(resultFilePath);
                Logger.LogMessage("Ltrar file location: {0}", ltrarFilePath);
            }
        }

        /// <summary>
        /// Gets the list of testrun messages from the service
        /// </summary>
        /// <returns></returns>
        public static TestRunMessages GetTestRunMessages(string testRunId)
        { 
            //Get test run messages
            return CltWebApi.GetTestRunMessages(testRunId);
        }

        /// <summary>
        /// Gets the list of testrun messages from the service
        /// </summary>
        /// <returns></returns>
        public static LoadTestErrors GetTestRunErrors(string testRunId)
        {
            //Get test run messages
            return CltWebApi.GetTestRunErrors(testRunId);
        }

        /// <summary>
        /// Gets the list of testrun counterinstances from the service
        /// </summary>
        /// <returns></returns>
        public static GenericListStructure<TestRunCounterInstance> GetTestRunCounterInstances(string testRunId)
        {
            return CltWebApi.GetTestRunCounterInstances(testRunId);
        }

        /// <summary>
        /// Gets the list of testrun countersamples from the service 
        /// </summary>
        /// <returns></returns>
        public static CounterSamplesResult GetTestRunCounterSamples(string testRunId, List<CounterSampleQueryDetails> queryDetails)
        {
            var queryList = new GenericListStructure<CounterSampleQueryDetails>();
            queryList.Count = queryDetails.Count;
            queryList.Value = queryDetails;
            return CltWebApi.GetTestRunCounterSamples(testRunId, queryList);
        }
    }
}
