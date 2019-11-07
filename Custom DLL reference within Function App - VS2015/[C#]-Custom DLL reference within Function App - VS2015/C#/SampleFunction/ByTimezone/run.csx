#r "SampleToSupportFunction.dll"

using System;
using System.Xml;
using System.Text;
using System.IO;
using SampleToSupportFunction;

public static void Run(string input, TraceWriter log)
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
    TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    var timeToString = Utility.GetDateBytimeZone(easternZone);
    //log.Info($"Time is : {timeToString}");
}