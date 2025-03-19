using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace RestAPITestProject.Utilities
{
    public class ExtentHelper
    {
        private static ExtentReports extent;
        private static ExtentTest test; 

        public void InitializeReport()
        {
            ExtentSparkReporter htmlReporter = new ExtentSparkReporter("C:\\Users\\2391446\\C#Training\\RestAPITestProject\\Reports\\extent.html");
            htmlReporter.Config.DocumentTitle = "Rest API Report";
            htmlReporter.Config.ReportName = "API Output Results";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        public ExtentTest CreateTest(string testName)
        {
            return extent.CreateTest(testName);
        }

        public void LogInfo(ExtentTest test, string message)
        {
            test.Log(Status.Info, message);
        }

        public void LogPass(ExtentTest test, string message)
        {
            test.Log(Status.Pass, message);
        }

        public void LogFail(ExtentTest test, string message)
        {
            test.Log(Status.Fail, message);
        }

        public void LogWarning(ExtentTest test, string message)
        {
            test.Log(Status.Warning, message);
        }

        public void FlushReport()
        {
            extent.Flush();
        }
    }
}
