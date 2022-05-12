using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// SeleniumTest test class with NUnit
    /// </summary>
    [TestFixture]
    public class SeleniumTestsNUnit : BaseSeleniumTest
    {
        /// <summary>
        /// open new invoice page and take screenshot - creating 2 pages.
        /// </summary>
        [Test]
        public void createbookingtest()
        {
            WebDriver.Navigate().GoToUrl("https://phptravels.net/");
            login();
            createbooking();
            Assert.IsTrue(WebDriver.FindElement(By.XPath("//*[@id='fadein']/section[1]/div/div/div/div/div[3]/div[1]/h3")).Text.Contains("Booking Invoice"));
        }

        [Test]
        public void screenshotInvoice()
        {
            WebDriver.Navigate().GoToUrl("https://phptravels.net/");
            login();

            IWebElement bookingTab = WebDriver.FindElement(By.XPath("//*[@id='fadein']/div[1]/div/div[3]/ul/li[2]/a"));
            bookingTab.Click();

            WebDriver.Wait().UntilPageLoad();

            IWebElement viewVoucherButton = WebDriver.FindElement(By.XPath("//*[@id='fadein']/section[1]/div/div[2]/div/div[1]/div/div/div[2]/div/table/tbody/tr/td[4]/div/a"));
            viewVoucherButton.Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles[1]);

            IWebElement sicko = WebDriver.FindElement(By.XPath("//*[@id='fadein']/section[1]/div/div/div/div/div[2]/div[1]/h3"));
            IWebElement oowee = WebDriver.FindElement(By.XPath("//*[@id='fadein']/section[1]"));

            this.WebDriver.CaptureScreenshot(this.TestObject, "C:/Users/tommy.swenson/Pictures", "Screencap", ScreenshotImageFormat.Png);
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles[0]);

            Assert.IsTrue(WebDriver.FindElement(By.XPath("//*[@id='fadein']/section[1]/div/div[1]/div/div[1]/div[1]/div/div/h2")).Displayed);
        }

        public void login()
        {
            IWebElement loginbutton = WebDriver.FindElement(By.XPath("//*[@id='fadein']/header/div[1]/div/div/div[2]/div/div/a[2]"));
            loginbutton.Click();


            ElementHandler.SetTextBox(this.WebDriver, By.XPath("//*[@id='fadein']/div[1]/div/div[2]/div[2]/div/form/div[1]/div/input"), "user@phptravels.com");
            /*IWebElement email = WebDriver.FindElement(By.XPath("//*[@id='fadein']/div[1]/div/div[2]/div[2]/div/form/div[1]/div/input"));
            email.Click();
            email.SendKeys("//*[@id='fadein']/div[1]/div/div[2]/div[2]/div/form/div[1]/div/input");*/

            ElementHandler.SetTextBox(this.WebDriver, By.XPath("//*[@id='fadein']/div[1]/div/div[2]/div[2]/div/form/div[2]/div[1]/input"), "demouser");
            /*IWebElement pass = WebDriver.FindElement(By.XPath("//*[@id='fadein']/div[1]/div/div[2]/div[2]/div/form/div[2]/div[1]/input"));
            pass.Click();
            pass.SendKeys("demouser");*/

            IWebElement submitloginbutton = WebDriver.FindElement(By.XPath("//*[@id='fadein']/div[1]/div/div[2]/div[2]/div/form/div[3]/button"));
            submitloginbutton.Click();
        }
        public void createbooking()
        {
            IWebElement hotelButton = WebDriver.Wait().ForElementExist(By.XPath("//*[@id='fadein']/header/div[2]/div/div/div/div/div[2]/nav/ul/li[2]/a"));
            hotelButton.Click();


            IWebElement searchHotelTextBox = WebDriver.Wait().ForElementExist(By.XPath("//*[@id='select2-hotels_city-container']"));
            searchHotelTextBox.Click();

            IWebElement searchHotelTextBoxClicked = WebDriver.Wait().ForElementExist(By.XPath("//*[@id='fadein']/span/span/span[1]/input"));
            searchHotelTextBoxClicked.SendKeys("islamabad");

            System.Threading.Thread.Sleep(6000);

            IWebElement dropdown_select = WebDriver.Wait().ForElementExist(By.XPath("//*[@id='fadein']/span/span/span[2]"));
            dropdown_select.Click();

            IWebElement SearchHotelButton = WebDriver.FindElement(By.XPath("//*[@id='submit']/span[1]"));
            SearchHotelButton.Click();

            IWebElement detailsButton = WebDriver.Wait().ForElementExist(By.XPath("//*[@id='islamabad marriott hotel']/div/div[2]/div/div[2]/div/a"));
            detailsButton.Click();

            WebDriver.Wait().UntilPageLoad();
            ElementHandler.ScrollIntoView(this.WebDriver, By.XPath("//*[@id='availability']/div[2]"));

            IWebElement bookbutton = WebDriver.Wait().ForElementExist(By.XPath("//*[@id='availability']/div[2]/div[1]/div[2]/div/div[2]/form/div/div[4]/div/div/button/span[1]"));
            System.Threading.Thread.Sleep(6000);
            bookbutton.Click();

            WebDriver.Wait().UntilPageLoad();
            ElementHandler.ScrollIntoView(this.WebDriver, By.XPath("//*[@id='myTab']/div[1]"));
            IWebElement banktransfercheckbox = WebDriver.FindElement(By.XPath("//*[@id='myTab']/div[1]/div/label/div"));
            System.Threading.Thread.Sleep(1000);
            banktransfercheckbox.Click();

            ElementHandler.ScrollIntoView(this.WebDriver, By.XPath("//*[@id='booking']"));

            ElementHandler.CheckCheckBox(this.WebDriver, By.XPath("//*[@id='fadein']/div[2]/form/section/div/div/div[1]/div[4]/div/div/div"), true);

            WebDriver.FindElement(By.XPath("//*[@id='booking']")).Click();

            WebDriver.Wait().UntilPageLoad();
        }
    }
}
