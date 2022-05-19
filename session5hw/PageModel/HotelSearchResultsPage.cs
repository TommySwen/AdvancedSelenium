using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for HotelSearchResultsPage
    /// </summary>
    public class HotelSearchResultsPage : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "PAGE.html";

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelSearchResultsPage" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public HotelSearchResultsPage(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// hotel details button
        /// </summary>
        private LazyElement detailsButton
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='islamabad marriott hotel']/div/div[2]/div/div[2]/div/a"), "Sample message"); }
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
        /// Open the details page
        /// </summary>
        public DetailsHotelPageModel OpenDetailsPage()
        {
            detailsButton.Click();
            return new DetailsHotelPageModel(TestObject);
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
