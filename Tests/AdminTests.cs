using NUnit.Framework;
using GeideaTests.Pages;
using GeideaTests.Utilities;


namespace GeideaTests.Tests
{
    /// <summary>
    /// Contains tests related to the Admin module.
    /// </summary>
    public class AdminTests : BaseTest
    {
        /// <summary>
        /// Verifies that filtering by user role 'Admin' displays only users with the 'Admin' role.
        /// </summary>
        [Test]
        public void TC2_AdminFilterVerification()
        {
            ExtentManager.CreateTest("TC2: Admin Filter Verification");

            // Step 1: Navigate to login page
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            // Step 2: Log in as Admin
            var loginPage = new LoginPage(Driver);
            loginPage.Login("Admin", "admin123");

            // Step 3: Navigate to Admin section and filter by role
            var adminPage = new AdminPage(Driver);
            adminPage.NavigateToAdmin();
            adminPage.FilterByUserRole("Admin");

            // Step 4: Validate that all roles shown are 'Admin'
            Assert.That(adminPage.AllRolesAre("Admin"), Is.True, "All users displayed should have the 'Admin' role");

            ExtentManager.LogPass("All users shown have role 'Admin'.");
        }
    }
}
