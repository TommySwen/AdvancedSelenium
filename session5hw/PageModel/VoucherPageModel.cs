using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for VoucherPageModel
    /// </summary>
    public class VoucherPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "PAGE.html";

        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public VoucherPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Sample lazy element
        /// </summary>
        private LazyElement VoucherHeader
        {
            get { return this.GetLazyElement(By.XPath("//*[@id='fadein']/section[1]/div/div[1]/div/div[1]/div[1]/div/div/h2"), "Voucher page header"); }
        }

        public bool IsVoucherDisplayed()
        {
            return VoucherHeader.Displayed;
        }

        public void CaptureVoucherScreenshot()
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles[1]);
            WebDriver.CaptureScreenshot(TestObject, "C:/Users/tommy.swenson/Pictures", "Screencap", ScreenshotImageFormat.Png);
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles[0]);
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
