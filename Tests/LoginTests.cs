using NUnit.Framework;
using GeideaTests.Pages;
using GeideaTests.Utilities;

namespace GeideaTests.Tests
{
    /// <summary>
    /// Contains test cases related to login functionality.
    /// </summary>
    public class LoginTests : BaseTest
    {
        /// <summary>
        /// Verifies that a user can log in successfully using valid credentials.
        /// Test data is loaded from a CSV file.
        /// </summary>
        /// <param name="username">The username to test</param>
        /// <param name="password">The corresponding password</param>
        [Test]
        [TestCaseSource(typeof(CsvReader), nameof(CsvReader.GetLoginData), new object[] { "TestData/LoginData.csv" })]
        public void TC1_LoginVerification(string username, string password)
        {
            ExtentManager.CreateTest("TC1: Login Verification");

            // Navigate to login page
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            var loginPage = new LoginPage(Driver);
            loginPage.Login(username, password);

            // Verify login success by checking if Dashboard is loaded
            Assert.That(loginPage.IsLoginSuccessful(), Is.True, "Login should navigate to dashboard");

            ExtentManager.LogPass("Login successful and verified.");
        }
    }
}
