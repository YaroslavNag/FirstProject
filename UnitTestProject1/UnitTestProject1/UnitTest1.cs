using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private string baseurl;

        private By FiveDays = By.XPath(@"//div[@class='sub_nav-item active'][1]/span[text()='Five-day weather forecast']");
        private By diagram = By.XPath(@"//div[@class='sub_nav-item'][1]/a[text()='Skew-T log-P diagram']");

        [TestInitialize]
        public void SetupTest()
        {
            var service = ChromeDriverService.CreateDefaultService(@"D:\Automation\UnitTestProject1\UnitTestProject1\bin\Debug\netcoreapp2.1");
            this.driver = new ChromeDriver(service);
            this.baseurl = "https://meteo.paraplan.net/en/";

            this.driver.Navigate().GoToUrl(this.baseurl);
        }

        [TestMethod]
        public void TestMethod1()
        {           
            this.driver.FindElement(By.XPath(@"//div[@class='sub_nav-item'][1]/a")).Click();
            ElementVis(FiveDays);
            ElementVis(diagram);
        }

        [TestCleanup]
        public void Clean()
        {
            this.driver.Close();
            this.driver.Quit();
        }

        public void ElementVis(By element, int timeoutSecs = 5)
        {
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeoutSecs)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }
    }
}   
