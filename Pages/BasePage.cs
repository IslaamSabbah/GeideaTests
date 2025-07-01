using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace GeideaTests.Pages
{
    /// <summary>
    /// Serves as a base class for all page objects.
    /// Provides shared utilities for element handling.
    /// </summary>
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        /// <summary>
        /// Initializes the base page with the given WebDriver.
        /// </summary>
        /// <param name="driver">The WebDriver instance used for browser interaction.</param>
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Waits until the element is visible and returns it.
        /// </summary>
        /// <param name="by">The selector used to locate the element.</param>
        /// <param name="timeoutInSeconds">How long to wait before timing out.</param>
        /// <returns>The visible web element.</returns>
        protected IWebElement WaitAndFindElement(By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        /// <summary>
        /// Waits until the element is clickable and returns it.
        /// </summary>
        /// <param name="by">The selector used to locate the element.</param>
        /// <param name="timeoutInSeconds">How long to wait before timing out.</param>
        /// <returns>The clickable web element.</returns>
        protected IWebElement WaitUntilClickable(By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
