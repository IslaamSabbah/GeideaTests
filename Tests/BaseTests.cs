using NUnit.Framework;
using OpenQA.Selenium;
using GeideaTests.Drivers;
using GeideaTests.Utilities;
using System;

namespace GeideaTests.Tests
{
    /// <summary>
    /// Base test class for initializing and cleaning up WebDriver and reports.
    /// All test classes should inherit from this.
    /// </summary>
    public class BaseTest : IDisposable
    {
        protected IWebDriver Driver;

        /// <summary>
        /// Initializes the Extent report before any tests run.
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ExtentManager.InitReport();
        }

        /// <summary>
        /// Creates a new WebDriver instance before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Driver = WebDriverFactory.CreateDriver();
        }

        /// <summary>
        /// Quits and disposes the WebDriver after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            try
            {
                Driver?.Quit();
                Driver?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during TearDown: " + ex.Message);
            }
        }

        /// <summary>
        /// Flushes the Extent report after all tests finish.
        /// </summary>
        [OneTimeTearDown]
        public void Cleanup()
        {
            ExtentManager.FlushReport();
        }

        /// <summary>
        /// Ensures WebDriver is disposed in case of manual cleanup.
        /// </summary>
        public void Dispose()
        {
            Driver?.Dispose();
        }
    }
}
