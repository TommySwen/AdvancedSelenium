#nullable disable
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Interactions;

namespace TestProject1
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Topic 1: start chrome in headless mode
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            chromeOptions.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            driver = new ChromeDriver(chromeOptions);
        }

        [Test]
        public void Test1()
        {
            // Topic 2: take screenshot
            driver.Navigate().GoToUrl("https://magenicautomation.azurewebsites.net/automation");
            IWebElement webElement = driver.FindElement(By.XPath("//*[@id='FoodTable']"));

            // Scroll to element to take screenshot of.
            Actions actions = new Actions(driver);
            actions.MoveToElement(webElement);
            actions.Perform();
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile("oowee.png", ScreenshotImageFormat.Png);

            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='body']/div[2]/h2")).Displayed);

            driver.Close();
        }

        [Test]
        public void Navigationtest()
        {
            // Topic 3: use navigation to go back a page
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://magenicautomation.azurewebsites.net/automation");

            driver.Navigate().GoToUrl("https://magenicautomation.azurewebsites.net/Static/Training1/loginpage.html");

            Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div/center/h2")).Displayed);

            driver.Navigate().Back();

            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='body']/div[2]/h2")).Displayed);

            driver.Close();
        }

        [Test]
        public void multiwindowtest()
        {
            // Topic 4: create multiple tabs and switch between them.
            driver.Navigate().GoToUrl("https://magenicautomation.azurewebsites.net/automation");
            var winHandleb4 = this.driver.CurrentWindowHandle;

            IWebElement newpagebutotn = driver.FindElement(By.XPath("//*[@id='ContactButton']/a"));
            Actions newtabclick = new Actions(driver).KeyDown(Keys.Control).Click(newpagebutotn).KeyUp(Keys.Control);
            newtabclick.Perform();

            for (int i = 1; i < driver.WindowHandles.Count; i++)
            {
                this.driver.SwitchTo().Window(driver.WindowHandles[i]);
                Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='MailTo']")).Displayed);
                driver.Close();
            }

            this.driver.SwitchTo().Window(winHandleb4);

            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='body']/div[2]/h2")).Displayed);

            driver.Close();
            
        }
    }
}
