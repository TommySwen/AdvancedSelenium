using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for DetailsHotelPageModel
    /// </summary>
    public class DetailsHotelPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "PAGE.html";

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailsHotelPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public DetailsHotelPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// availability
        /// </summary>
        private LazyElement Availability
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='availability']/div[2]"), "Availability"); }
        }

        /// <summary>
        /// availability
        /// </summary>
        private LazyElement BookButton
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='availability']/div[2]/div[1]/div[2]/div/div[2]/form/div/div[4]/div/div/button/span[1]"), "book button"); }
        }

        public BookingPageModel OpenBookingPage()
        {
            ElementHandler.ScrollIntoView(Availability);
            //originaly did some waiting here for scroll to complete
            System.Threading.Thread.Sleep(2000);
            BookButton.Click();
            return new BookingPageModel(TestObject);
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
