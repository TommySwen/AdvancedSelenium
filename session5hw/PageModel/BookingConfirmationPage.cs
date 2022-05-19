using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for BookingConfirmationPage
    /// </summary>
    public class BookingConfirmationPage : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "hotels/booking/invoice/";

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingConfirmationPage" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public BookingConfirmationPage(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Sample lazy element
        /// </summary>
        private LazyElement BookingInvoice
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='fadein']/section[1]/div/div/div/div/div[3]/div[1]/h3"), "booking invoice"); }
        }

        public string getConfirmation()
        {
            return BookingInvoice.Text;
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
