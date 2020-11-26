using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebDriverTest
{
    public class Tests
    {
        IWebDriver driver;
        string websiteUrl = "https://www2.razer.com/eu-en";

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl(websiteUrl);

            IWebElement storeButton = driver.FindElement(By.LinkText("STORE"));
            storeButton.Click();

            IWebElement gamingMousesButton = driver.FindElement(By.CssSelector(".gaming-mice>a"));
            gamingMousesButton.Click();

            IWebElement mouseChoiceButton = driver.FindElement(By.CssSelector(".new-product-list>a"));
            mouseChoiceButton.Click();

            IWebElement selectColorCombobox = driver.FindElement(By.XPath("//select[@class='store_select_variant']/option[@value='5442682400']"));
            selectColorCombobox.Click();

            IWebElement addToCartButton = driver.FindElement(By.CssSelector("#store_product_button>a"));
            addToCartButton.Click();

            Assert.IsTrue(true);
        }

        [TearDown]
        public void TearDownTests()
        {
            driver.Quit();
        }
    }
}