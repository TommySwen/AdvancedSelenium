using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for BookingPageModel
    /// </summary>
    public class BookingPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "PAGE.html";

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public BookingPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Button to book the room
        /// </summary>
        private LazyElement BookingButton
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='booking']"), "book button"); }
        }

        /// <summary>
        /// the checkbox to agree to terms And Conditions
        /// </summary>
        private LazyElement TermsAndConditionsCheckbox
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='fadein']/div[2]/form/section/div/div/div[1]/div[4]/div/div/div/label"), "terms And Conditions checkbox"); }
        }

        /// <summary>
        /// cookie popup that gets in the way
        /// </summary>
        private LazyElement CookiePopup
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='cookie_stop']"), "cookie usage popup"); }
        }

        

        public BookingConfirmationPage CompleteBooking()
        {
            System.Threading.Thread.Sleep(2000);
            ElementHandler.ScrollIntoView(BookingButton);
            System.Threading.Thread.Sleep(2000);
            CookiePopup.Click();
            ElementHandler.CheckCheckBox(TermsAndConditionsCheckbox, true);
            BookingButton.Click();
            return new BookingConfirmationPage(TestObject);
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
