using OpenQA.Selenium;

namespace GeideaTests.Pages
{
    /// <summary>
    /// Represents the login page and provides methods for user authentication.
    /// </summary>
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) {}

        // Locators for login form elements
        private IWebElement Username => WaitAndFindElement(By.Name("username"));
        private IWebElement Password => WaitAndFindElement(By.Name("password"));
        private IWebElement LoginBtn => WaitUntilClickable(By.CssSelector("button[type='submit']"));

        /// <summary>
        /// Performs login with the provided credentials.
        /// </summary>
        /// <param name="username">The username to enter.</param>
        /// <param name="password">The password to enter.</param>
        public void Login(string username, string password)
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
            LoginBtn.Click();
        }

        /// <summary>
        /// Checks whether login was successful by verifying presence of the Dashboard header.
        /// </summary>
        /// <returns>True if Dashboard is displayed, otherwise false.</returns>
        public bool IsLoginSuccessful()
        {
            try
            {
                WaitAndFindElement(By.XPath("//h6[text()='Dashboard']"));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
