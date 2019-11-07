using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using CloudLoadTestingClient.WebApiModels;
using Newtonsoft.Json;
using System;

namespace CloudLoadTestingClient
{ 
    public class CltWebApi
    {
        public static IEnumerable<TestRun> GetTestRuns(string queryParam = null, string value =  null)
        {
            try
            {
                if(!string.IsNullOrEmpty(queryParam) && !string.IsNullOrEmpty(value))
                    return CltHttpClientWrapper.Get<IEnumerable<TestRun>>(string.Format("/_apis/clt/testruns?{0}={1}", queryParam, value)).Result;
                return CltHttpClientWrapper.Get<IEnumerable<TestRun>>("/_apis/clt/testruns").Result;
            }
            catch (AggregateException aggregateException)
            {
                Exception innerException = aggregateException.InnerException;
                string exceptionMessage = "GetTestRuns failed with the following error";
                while (innerException != null)
                {
                    exceptionMessage = exceptionMessage + "\n\t" + innerException.Message;
                    innerException = innerException.InnerException;
                }
                throw new Exception(exceptionMessage);
            }
        }

        public static TestRun GetTestRun(string testRunId)
        {
            try
            {
                return CltHttpClientWrapper.Get<TestRun>("/_apis/clt/testruns/" + testRunId).Result;
            }
            catch (AggregateException aggregateException)
            {
                Exception innerException = aggregateException.InnerException;
                string exceptionMessage = "GetTestRun failed with the following error";
                while (innerException != null)
                {
                    exceptionMessage = exceptionMessage + "\n\t" + innerException.Message;
                    innerException = innerException.InnerException;
                }
                throw new Exception(exceptionMessage);
            }
        }

        public static TestResults GetTestRunResults(string testRunId)
        {
            try
            {
                return CltHttpClientWrapper.Get<TestResults>("/_apis/clt/testruns/" + testRunId + "/results").Result;
            }
            catch (AggregateException aggregateException)
            {
                Exception innerException = aggregateException.InnerException;
                string exceptionMessage = "GetTestRunResults failed with the following error";
                while (innerException != null)
                {
                    exceptionMessage = exceptionMessage + "\n\t" + innerException.Message;
                    innerException = innerException.InnerException;
                }
                throw new Exception(exceptionMessage);
            }
        }
        public static TestRunMessages GetTestRunMessages(string testRunId)
        {
            try
            {
                return CltHttpClientWrapper.Get<TestRunMessages>("/_apis/clt/testruns/" +  testRunId + "/messages").Result;
             
            }
            catch (AggregateException aggregateException)
            {
                Exception innerException = aggregateException.InnerException;
                string exceptionMessage = "GetTestRunMessages failed with the following error";
                while (innerException != null)
                {
                    exceptionMessage = exceptionMessage + "\n\t" + innerException.Message;
                    innerException = innerException.InnerException;
                }
                throw new Exception(exceptionMessage);
            }
        }
        public static TestRun CreateTestRun(TestRun testRun)
        {
            try
            {
                var createdTestRun = CltHttpClientWrapper.Post<TestRun>("/_apis/clt/testruns", GetStringContentForObject(testRun)).Result;
                return createdTestRun;
            }
            catch (AggregateException aggregateException)
            {
                Exception innerException = aggregateException.InnerException;
                string exceptionMessage = "CreateTestRun failed with the following error";
                while (innerException != null)
                {
                    exceptionMessage = exceptionMessage + "\n\t" + innerException.Message;
                    innerException = innerException.InnerException;
                }
                throw new Exception(exceptionMessage);
            }
        }

        public static TestDrop CreateTestDrop()
        {
            try
            {
                var testDrop = new TestDrop() { DropType = TestDropType };
                return CltHttpClientWrapper.Post<TestDrop>("/_apis/clt/testdrops", GetStringContentForObject(testDrop)).Result;
            }
            catch (AggregateException aggregateException)
            {
                Exception innerException = aggregateException.InnerException;
                string exceptionMessage = "Test Drop Creation failed with the following error";
                while (innerException != null)                    
                {
                   exceptionMessage = exceptionMessage + "\n\t" + innerException.Message;
                   innerException = innerException.InnerException;
                }
                throw new Exception(exceptionMessage);
            }
        }

        public static void StartTestRun(string testRunId)
        {
            try
            {
                var testRun = new TestRun { State = TestRunState.Queued };
                CltHttpClientWrapper.Patch("/_apis/clt/testruns/" + testRunId, GetStringContentForObject(testRun)).Wait();
            }
            catch (AggregateException aggregateException)
            {
                Exception innerException = aggregateException.InnerException;
                string exceptionMessage = "Starting test run failed with the following error";
                while (innerException != null)
                {
                    exceptionMessage = exceptionMessage + "\n\t" + innerException.Message;
                    innerException = innerException.InnerException;
                }
                throw new Exception(exceptionMessage);
            }
        }

        public static GenericListStructure<TestRunCounterInstance> GetTestRunCounterInstances(string testRunId)
        {
            try
            {
                return
                    CltHttpClientWrapper.Get<GenericListStructure<TestRunCounterInstance>>("/_apis/clt/testruns/" + testRunId +
                                                                           "/counterInstances?groupNames=Default").Result;
            }
            catch (AggregateException aggregateException)
            {
                Exception innerException = aggregateException.InnerException;
                string exceptionMessage = "getting test run counter instances failed with the following error";
                while (innerException != null)
                {
                    exceptionMessage = exceptionMessage + "\n\t" + innerException.Message;
                    innerException = innerException.InnerException;
                }
                throw new Exception(exceptionMessage);
            }
        }

        public static CounterSamplesResult GetTestRunCounterSamples(string testRunId, GenericListStructure<CounterSampleQueryDetails> queryDetails)
        {
            try
            {
                return
                    CltHttpClientWrapper.Post<CounterSamplesResult>("/_apis/clt/testruns/" + testRunId +
                                                                           "/counterSamples", GetStringContentForObject(queryDetails)).Result;
            }
            catch (AggregateException aggregateException)
            {
                Exception innerException = aggregateException.InnerException;
                string exceptionMessage = "getting test run samples failed with the following error";
                while (innerException != null)
                {
                    exceptionMessage = exceptionMessage + "\n\t" + innerException.Message;
                    innerException = innerException.InnerException;
                }
                throw new Exception(exceptionMessage);
            }
        }

        public static LoadTestErrors GetTestRunErrors(string testRunId)
        {
            try
            {
                return
                    CltHttpClientWrapper.Get<LoadTestErrors>("/_apis/clt/testruns/" + testRunId +
                                                                           "/Errors?detailed=true").Result;
            }
            catch (AggregateException aggregateException)
            {
                Exception innerException = aggregateException.InnerException;
                string exceptionMessage = "getting test run samples failed with the following error";
                while (innerException != null)
                {
                    exceptionMessage = exceptionMessage + "\n\t" + innerException.Message;
                    innerException = innerException.InnerException;
                }
                throw new Exception(exceptionMessage);
            }
        }

        private static HttpContent GetStringContentForObject(object obj)
        {
            var objJson = JsonConvert.SerializeObject(obj);
            return new StringContent(objJson, Encoding.UTF8, "application/json");
        }

        private const string TestDropType = "TestServiceBlobDrop";
    }
}
