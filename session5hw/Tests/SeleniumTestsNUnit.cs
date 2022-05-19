using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System;
using System.Drawing;
using OpenQA.Selenium.Interactions;
using PageModel;

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
        /// create new booking could not find an area to specify wine bottles.
        /// once the room is booked this test fails because the room is marked as already reserved, so cannot reserve again.
        /// </summary>
        //[Test]
        //[TestCase("Chrome")]
        //[TestCase("FireFox")]
        //[TestCase("edge")]
        public void createbookingtest(String browser)
        {
            if (browser == "Chrome")
            {
                ChromeOptions cop = new ChromeOptions();
                this.WebDriver = new RemoteWebDriver(new Uri("http://localhost:5555"), cop);
            }
            else if (browser == "FireFox")
            {
                FirefoxOptions fop = new FirefoxOptions();
                this.WebDriver = new RemoteWebDriver(new Uri("http://localhost:5555"), fop);
            }
            else if (browser == "edge")
            {
                EdgeOptions eop = new EdgeOptions();
                this.WebDriver = new RemoteWebDriver(new Uri("http://localhost:5555"), eop);
            }
            System.Threading.Thread.Sleep(6000);
            WebDriver.Manage().Window.Maximize();

            LoginPageModel lpm = new LoginPageModel(TestObject);
            lpm.OpenPage();

            AccountDashboardPageModel dpm = lpm.loginWithCred("user@phptravels.com", "demouser");
            HotelSearchPageModel hspm = dpm.OpenHotelSearchPage();
            HotelSearchResultsPage hsrpm = hspm.SearchForGivenHotel("islamabad");
            DetailsHotelPageModel dhpm = hsrpm.OpenDetailsPage();
            BookingPageModel bpm = dhpm.OpenBookingPage();
            BookingConfirmationPage bcp = bpm.CompleteBooking();
            System.Threading.Thread.Sleep(6000);
            Assert.IsTrue(bcp.getConfirmation().Contains("Booking Invoice"));
        }

        [Test]
        [TestCase("edge")]
        [TestCase("Chrome")]
        [TestCase("FireFox")]
        public void screenshotInvoice(string browser)
        {
            if (browser == "Chrome")
            {
                ChromeOptions cop = new ChromeOptions();
                this.WebDriver = new RemoteWebDriver(new Uri("http://localhost:5555"), cop);
            }
            else if (browser == "FireFox")
            {
                FirefoxOptions fop = new FirefoxOptions();
                this.WebDriver = new RemoteWebDriver(new Uri("http://localhost:5555"), fop);
            }
            else if (browser == "edge")
            {
                EdgeOptions eop = new EdgeOptions();
                this.WebDriver = new RemoteWebDriver(new Uri("http://localhost:5555"), eop);
            }
            System.Threading.Thread.Sleep(6000);
            WebDriver.Manage().Window.Maximize();

            LoginPageModel lpm = new LoginPageModel(TestObject);
            lpm.OpenPage();
            AccountDashboardPageModel dpm = lpm.loginWithCred("user@phptravels.com", "demouser");
            BookingsModel bm = dpm.OpenBookingTab();
            VoucherPageModel vpm = bm.OpenBookingVoucher();
            vpm.CaptureVoucherScreenshot();

            Assert.IsTrue(vpm.IsVoucherDisplayed() == true);
        }
    }
}
