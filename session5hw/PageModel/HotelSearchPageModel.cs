using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for HotelSearchPageModel
    /// </summary>
    public class HotelSearchPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "PAGE.html";

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelSearchPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public HotelSearchPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// hotelsearchbox
        /// </summary>
        private LazyElement SearchHotelTextBox
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='select2-hotels_city-container']"), "search Hotel Textbox"); }
        }

        /// <summary>
        /// hotelsearch box which has been clicked
        /// </summary>
        private LazyElement HotelSearchBoxClicked
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='fadein']/span/span/span[1]/input"), "search Hotel Textbox that has been clicked"); }
        }

        /// <summary>
        /// dropdown which appears after text is entered into hotel search box
        /// </summary>
        private LazyElement searchDropdown
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='fadein']/span/span/span[2]"), "dropdown of search results"); }
        }

        /// <summary>
        /// Button to search for hotels
        /// </summary>
        private LazyElement SearchHotelButton
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='submit']/span[1]"), "search hotel button"); }
        }

        public HotelSearchResultsPage SearchForGivenHotel(string hotelname)
        {
            SearchHotelTextBox.Click();
            HotelSearchBoxClicked.SendKeys(hotelname);
            // need to wait for the search results to populate dropdown
            System.Threading.Thread.Sleep(6000);
            searchDropdown.Click();
            SearchHotelButton.Click();
            return new HotelSearchResultsPage(TestObject);
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
