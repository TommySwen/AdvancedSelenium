using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for BookingsModel
    /// </summary>
    public class BookingsModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "PAGE.html";

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingsModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public BookingsModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// button to view the Voucher for a Booking
        /// </summary>
        private LazyElement ViewVoucherButton
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='fadein']/section[1]/div/div[2]/div/div[1]/div/div/div[2]/div/table/tbody/tr/td[4]/div/a"), "view the Voucher"); }
        }

        
        public VoucherPageModel OpenBookingVoucher()
        {
            ViewVoucherButton.Click();
            return new VoucherPageModel(TestObject);
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
