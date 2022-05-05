#nullable disable
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace hwsession3
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            //chromeOptions.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            var path = @"C:\Users\tommy.swenson\Source\repos\hwsession3\hwsession3\drivers\";
            chromeOptions.BinaryLocation = @"C:\Users\tommy.swenson\Source\repos\hwsession3\hwsession3\drivers\chromedriver.exe";
            driver = new ChromeDriver(path);
        }

        [Test]
        public void DragAndDropTest()
        {
            driver.Navigate().GoToUrl("https://magenicautomation.azurewebsites.net/automation");
            IWebElement draggable = driver.FindElement(By.XPath("//*[@id='draggable']/p"));


            Actions scroller = new Actions(driver);
            scroller.MoveToElement(draggable).Perform();

            Actions move = new Actions(driver);
            move.DragAndDropToOffset(draggable, 90, 30);
            move.Perform();
            IWebElement box = driver.FindElement(By.XPath("//*[@id='DROPPED']"));
            Assert.IsTrue(box.Displayed);
            driver.Close();
        }

        [Test]
        public void UploadImageTest()
        {
            driver.Navigate().GoToUrl("https://magenicautomation.azurewebsites.net/automation");
            IWebElement uploadImageButton = driver.FindElement(By.XPath("//*[@id='photo']"));

            // need to make sure element is in focus before running test
            string jstoexecute = string.Format("window.scroll(0, {0});", uploadImageButton.Location.Y);
            ((IJavaScriptExecutor)driver).ExecuteScript(jstoexecute);

            string path = "C:/Users/tommy.swenson/Pictures/Saved Pictures/eggface.JPG";
            uploadImageButton.SendKeys(path);
            Assert.IsTrue(uploadImageButton.Displayed);
            driver.Close();
        }
    }
}