using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// login page
    /// </summary>
    public class LoginPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "login";

        /// <summary>
        /// Initializes a new instance of the loginpagemodel
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public LoginPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Username Input
        /// </summary>
        private LazyElement UsernameInput
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='fadein']/div[1]/div/div[2]/div[2]/div/form/div[1]/div/input"), "username input"); }
        }

        /// <summary>
        /// Username Input
        /// </summary>
        private LazyElement PasswordInput
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='fadein']/div[1]/div/div[2]/div[2]/div/form/div[2]/div[1]/input"), "Password input"); }
        }

        /// <summary>
        /// login button
        /// </summary>
        private LazyElement LoginButton
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='fadein']/div[1]/div/div[2]/div[2]/div/form/div[3]/button"), "Login Button"); }
        }

        /// <summary>
        /// enter given username and password to the username and password input fields then click log in
        /// </summary>
        public AccountDashboardPageModel loginWithCred(string username, string password)
        {
            UsernameInput.SetTextBox(username); // or sendkeys?
            PasswordInput.SetTextBox(password);
            LoginButton.Click();
            return new AccountDashboardPageModel(TestObject);
        }

        /// <summary>
        /// Open the page
        /// </summary>
        public void OpenPage()
        {
            // sample open login page
            this.TestObject.WebDriver.Navigate().GoToUrl(PageUrl);
        }

        /// <summary>
        /// Check if the login page is loaded
        /// </summary>
        public override bool IsPageLoaded()
        {
            return this.WebDriver.Url.Equals(PageUrl, System.StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
