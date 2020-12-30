using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebDriverTest
{
    public class Tests
    {
        IWebDriver driver;
        string websiteUrl = "https://www.epicgames.com/store/ru/";
        string loginFormUrl= "https://www.epicgames.com/id/login/epic/";
        string wishListUrl = "https://www.epicgames.com/store/en-US/wishlist";
        string email = "testmailboxepam@gmail.com";
        string password = "MCH-kc8-hWG-bLf";

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void AddToFavoriteTest()
        {
            driver.Navigate().GoToUrl(websiteUrl);

            IWebElement selectGameButton = driver.FindElement(By.XPath("//span[text()='Rocket League®']"));
            selectGameButton.Click();

            IWebElement addToWishList = driver.FindElement(By.XPath("//div[@class='css-1mgfzks-Tooltip-styles__main']"));
            addToWishList.Click();

            driver.Navigate().GoToUrl(wishListUrl);

            IWebElement wishItemsCount = driver.FindElement(By.XPath("//div[@class='css-189bt6a-WishlistHeader-styles__totalWrapper'/span"));
            bool itemCount = int.Parse(wishItemsCount.Text) == 1 ? true : false;

            Assert.IsTrue(itemCount);
        }

        [Test]
        public void LoginEpicTest()
        {
            driver.Navigate().GoToUrl(loginFormUrl);

            IWebElement emailField = driver.FindElement(By.Id("email"));
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("sign-in"));

            emailField.SendKeys(email);
            passwordField.SendKeys(password);
            loginButton.Click();

            string actualUrl = driver.Url;
            Assert.AreEqual(websiteUrl, actualUrl);
        }

        [TearDown]
        public void TearDownTests()
        {
            driver.Quit();
        }
    }
}