using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for AccountDashboardPageModel
    /// </summary>
    public class AccountDashboardPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "account/dashboard";

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDashboardPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public AccountDashboardPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// HotelButton
        /// </summary>
        private LazyElement HotelButton
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='fadein']/header/div[2]/div/div/div/div/div[2]/nav/ul/li[2]/a"), "hotells button"); }
        }

        /// <summary>
        /// bookings button
        /// </summary>
        private LazyElement BookingTabButton
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='fadein']/div[1]/div/div[3]/ul/li[2]/a"), "booking tab button"); }
        }
        public BookingsModel OpenBookingTab()
        {
            BookingTabButton.Click();
            return new BookingsModel(TestObject);
        }
        public HotelSearchPageModel OpenHotelSearchPage()
        {
            HotelButton.Click();
            return new HotelSearchPageModel(TestObject);
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
