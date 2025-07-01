using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace GeideaTests.Utilities
{
    /// <summary>
    /// Manages ExtentReports initialization and logging.
    /// </summary>
    public static class ExtentManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static ExtentSparkReporter _reporter;

        /// <summary>
        /// Initializes the Extent Report and creates the report file under the Reports folder at project root.
        /// </summary>
        public static void InitReport()
        {
            var projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.FullName;
            var reportDir = Path.Combine(projectRoot, "Reports");
            Directory.CreateDirectory(reportDir); // Create Reports folder if not exists

            var reportPath = Path.Combine(reportDir, $"GeideaTests_Report_{DateTime.Now:yyyyMMdd_HHmmss}.html");

            _reporter = new ExtentSparkReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(_reporter);
        }

        /// <summary>
        /// Starts logging for a new test case in the report.
        /// </summary>
        public static void CreateTest(string name)
        {
            _test = _extent.CreateTest(name);
        }

        /// <summary>
        /// Logs a passed step in the report.
        /// </summary>
        public static void LogPass(string message)
        {
            _test.Pass(message);
        }

        /// <summary>
        /// Logs a failed step in the report.
        /// </summary>
        public static void LogFail(string message)
        {
            _test.Fail(message);
        }

        /// <summary>
        /// Flushes and finalizes the report. Must be called once all tests are executed.
        /// </summary>
        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
