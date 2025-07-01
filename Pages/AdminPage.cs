using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace GeideaTests.Pages
{
    /// <summary>
    /// Represents the Admin page and its interactions.
    /// </summary>
    public class AdminPage : BasePage
    {
        public AdminPage(IWebDriver driver) : base(driver) {}

        private By adminMenu = By.XPath("//span[text()='Admin']");
        private By userRoleDropdown = By.XPath("//label[text()='User Role']/following::div[contains(@class,'oxd-select-wrapper')][1]");
        private By loadingOverlay = By.CssSelector(".oxd-loading-spinner");
        private By searchButton = By.XPath("//button[@type='submit']");
        private By rolesInTable = By.XPath("//div[@role='rowgroup']//div[@role='row']//div[@role='cell'][3]");

        /// <summary>
        /// Clicks on the Admin menu to open the Admin section.
        /// </summary>
        public void NavigateToAdmin()
        {
            WaitUntilClickable(adminMenu).Click();
        }

        /// <summary>
        /// Applies a filter on the user role dropdown and waits for the result.
        /// </summary>
        /// <param name="role">The user role to filter by (e.g., "Admin").</param>
        public void FilterByUserRole(string role)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementToBeClickable(userRoleDropdown)).Click();

            var roleOption = By.XPath($"//div[@role='option']//span[text()='{role}']");
            wait.Until(ExpectedConditions.ElementToBeClickable(roleOption)).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(searchButton)).Click();

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loadingOverlay));
        }

        /// <summary>
        /// Validates that all users displayed in the table have the expected role.
        /// </summary>
        /// <param name="expected">The expected role name (e.g., "Admin").</param>
        /// <returns>True if all displayed roles match the expected role, otherwise false.</returns>
        public bool AllRolesAre(string expected)
        {
            var elements = Driver.FindElements(rolesInTable);
            Console.WriteLine($"Checking {elements.Count} role cells:");

            foreach (var roleCell in elements)
            {
                var roleText = roleCell.Text.Trim();
                Console.WriteLine($"Found role: '{roleText}'");

                if (!roleText.Equals(expected, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Mismatch found - Expected: '{expected}', Found: '{roleText}'");
                    return false;
                }
            }

            return true;
        }
    }
}
