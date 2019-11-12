using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using CloudLoadTestingClient;
using System;
using System.IO;
using CloudLoadTestingClient.WebApiModels;

namespace CloudLoadTesting
{
    class CloudLoadTestingClient
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowCommandlineHelp();
                return;
            }
            try
            {
                string command = args[0].ToLowerInvariant();
                switch (command)
                {
                    case "/testruns":
                        {
                            var tests = CltOperations.GetTestRuns();
                            tests.ToList().ForEach(test => LogTestRunDetails(test));
                        }
                        break;

                    case "/gettestrunsbyname":
                        {
                            var filteredTestsByName = CltOperations.GetTestRuns("name", args[1]);
                            filteredTestsByName.ToList().ForEach(test => LogTestRunDetails(test));
                        }

                        break;

                    case "/gettestrunsbystatus":
                        {
                            TestRunState testRunState;
                            if (!Enum.TryParse(args[1], true, out testRunState))
                            {
                                ShowCommandLineHelpForTestStates();
                            }
                            else
                            {
                                var filteredTestsByStatus = CltOperations.GetTestRuns("status", args[1]);
                                filteredTestsByStatus.ToList().ForEach(test => LogTestRunDetails(test));
                            }
                        }

                        break;

                    case "/gettestrunsbydays":
                        {
                            var currentDate = DateTime.UtcNow;
                            var fromDate = currentDate.AddDays(0.0 - Double.Parse(args[1]));
                            var filteredTestsByDays = CltOperations.GetTestRuns("fromdate", fromDate.ToString("o"));
                            filteredTestsByDays.ToList().ForEach(test => LogTestRunDetails(test));
                        }

                        break;
                    case "/starttestrun":
                        {
                            var newTestRun = CltOperations.CreateAndStartRun(args[1], args[2]);
                            if (newTestRun == null)
                            {
                                break;
                            }
                            LogTestRunDetails(newTestRun);
                            string testRunId = newTestRun.Id;
                            while (newTestRun.State != TestRunState.Aborted &&
                                newTestRun.State != TestRunState.Completed &&
                                newTestRun.State != TestRunState.Error)
                            {
                                Thread.Sleep(30 * 1000);
                                newTestRun = CltOperations.GetTestRun(testRunId);
                                LogTestRunDetails(newTestRun);
                            }

                            LogTestRunDetails(newTestRun);
                            // log test run messages for Aborted/Error runs
                            if (newTestRun.State == TestRunState.Aborted || newTestRun.State == TestRunState.Error)
                            {
                                var testRunMessages = CltOperations.GetTestRunMessages(testRunId);
                                testRunMessages.Value.ForEach(testRunMessage => LogTestRunMessage(testRunMessage));
                            }
                        }
                        break;

                    case "/testrun":
                        {
                            var testRun = CltOperations.GetTestRun(args[1]);
                            LogTestRunDetails(testRun);
                        }
                        break;

                    case "/downloadresult":
                        {
                            CltOperations.DownloadResult(args[1]);
                        }
                        break;
                    case "/gettestrunmessages":
                        {
                            var testRunMessages = CltOperations.GetTestRunMessages(args[1]);
                            testRunMessages.Value.ForEach(testRunMessage => LogTestRunMessage(testRunMessage));
                        }
                        break;

                    case "/getavgresponsetime":
                        {
                            var counterInstanceList = CltOperations.GetTestRunCounterInstances(args[1]);
                            var avgResponseTimeInstance =
                                counterInstanceList.Value.First(x => x.CounterName.Equals("Avg. Response Time"));
                            var counterSampleQueryDetails = new List<CounterSampleQueryDetails>()
                        {
                            new CounterSampleQueryDetails()
                            {
                                CounterInstanceId = avgResponseTimeInstance.CounterInstanceId,     
                                ToInterval = -1
                            }
                        };
                            var samplesResult = CltOperations.GetTestRunCounterSamples(args[1], counterSampleQueryDetails);
                            foreach (var instanceSample in samplesResult.InstanceSamples)
                            {
                                foreach (var counterSample in instanceSample.Samples)
                                {
                                    Logger.LogMessage("Interval no.: {0}, Avg. Response Time : {1}", counterSample.IntervalNumber, counterSample.ComputedValue);
                                }
                            }

                        }

                        break;

                    case "/getuserload":
                        {
                            var newCounterInstanceList = CltOperations.GetTestRunCounterInstances(args[1]);
                            var userLoadInstance =
                                newCounterInstanceList.Value.First(x => x.CounterName.Equals("User Load"));
                            var newCounterSampleQueryDetails = new List<CounterSampleQueryDetails>()
                        {
                            new CounterSampleQueryDetails()
                            {
                                CounterInstanceId = userLoadInstance.CounterInstanceId,
                                ToInterval = -1
                            }
                        };
                            var samplesResultForUserLoad = CltOperations.GetTestRunCounterSamples(args[1], newCounterSampleQueryDetails);
                            foreach (var instanceSample in samplesResultForUserLoad.InstanceSamples)
                            {
                                foreach (var counterSample in instanceSample.Samples)
                                {
                                    Logger.LogMessage("Interval no.: {0}, User Load : {1}", counterSample.IntervalNumber, counterSample.ComputedValue);
                                }
                            }

                        }

                        break;

                    case "/gettesterrors":
                    {
                        var loadTestErrors = CltOperations.GetTestRunErrors(args[1]);
                        LogTestRunErrors(loadTestErrors);
                    }
                        break;
                    case "/?":
                        ShowCommandlineHelp();
                        break;
                }
            }
            catch (Exception e)
            {
                Logger.LogMessage("CloudLoadTestingClient.exe failed with the following exception : {0}", e.Message);
            }
        }

        private static void ShowCommandlineHelp()
        {
            Logger.LogMessage("CloudLoadTestingClient.exe [/testruns] | [/gettestrunsbyname <testrunname>] | [/gettestrunsbystatus <testrunstatus>] | [/gettestrunsbydays <for last how many days>]| [/starttestrun <testrundir> <testrunname>] | [/testrun <testrunid>] | [downloadresult <testrunid>] | [/gettestrunmessages <testrunid>] | [/getavgresponsetime <testrunid>] | [/getuserload <testrunid>]");
        }

        private static void ShowCommandLineHelpForTestStates()
        {
            Logger.LogMessage("Possible test states: {0} | {1} | {2} | {3} | {4} | {5} | {6}", TestRunState.Completed.ToString(), TestRunState.InProgress.ToString(), TestRunState.Aborted.ToString(), TestRunState.Error.ToString(), TestRunState.Queued.ToString(), TestRunState.Pending.ToString(), TestRunState.Stopping.ToString());
        }

        private static void LogTestRunDetails(TestRun testRun)
        {
            Logger.LogMessage(string.Format(CultureInfo.InvariantCulture, "TestRun: Name = {0} , Id = {1}, State = {2}", testRun.Name, testRun.Id, testRun.State));
        }

        private static void LogTestRunErrors(LoadTestErrors errors)
        {
            Logger.LogMessage(string.Format(CultureInfo.InvariantCulture, "Total number of errors: {0}", errors.Occurrences));
            foreach (var errorType in errors.Types)
            {
                foreach (var errorSubType in errorType.SubTypes)
                {
                    foreach (var error in errorSubType.ErrorDetailList)
                    {
                      Logger.LogMessage(string.Format(CultureInfo.InvariantCulture, "ErrorType: {0}, SubType: {1}, Occurrences: {2}, ScenarioName: {3}, TestCaseName: {4}, Message: {5},  StackTrace: {6}", errorType.TypeName, errorSubType.SubTypeName, errorSubType.Occurrences, error.ScenarioName, error.TestCaseName, error.MessageText, error.StackTrace));  
                    }         
                }   
            }
        }

        private static void LogTestRunMessage(TestRunMessage testRunMessage)
        {
            if (testRunMessage.MessageType == MessageType.Critical || testRunMessage.MessageType == MessageType.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (testRunMessage.MessageType == MessageType.Warning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Logger.LogMessage(string.Format(CultureInfo.InvariantCulture, "MessageType: {0} , Source:  {1}, Message: {2}", testRunMessage.MessageType, testRunMessage.MessageSource, testRunMessage.Message));
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
