using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace SauceDemoE2E.Pages
{
    public class AddToCartPage
        {
            private IWebDriver driver;

            public AddToCartPage(IWebDriver driver)
            {

                this.driver = driver;
            }
            //locators on addtocart page

            By clickproduct = By.XPath("//div[normalize-space()='Sauce Labs Backpack']");
            By addtocartbtn = By.XPath("//button[contains(@id, 'add-to-cart')]");

            By carticon = By.XPath("//a[@class='shopping_cart_link']");
      

        public void clickproductwanted()
            {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement product = wait.Until(drv => drv.FindElement(clickproduct));
            product.Click();
            //Thread.Sleep(3000);
            //driver.FindElement(clickproduct).Click();

            Thread.Sleep(2000);
        }
        public void AddToCart()
            {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement product = wait.Until(drv => drv.FindElement(addtocartbtn));
            product.Click();
            //driver.FindElement(addtocartbtn).Click();
            //Thread.Sleep(2000);
        }
            public void clickcart()
            {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement product = wait.Until(drv => drv.FindElement(carticon));
            product.Click();
            //driver.FindElement(carticon).Click();
            //Thread.Sleep(2000);
        }
            public void WaitForProductPageToLoad()
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                wait.Until(driver => driver.Url.Contains("inventory.html")); // ✅ No need for ExpectedConditions
                Console.WriteLine("✅ Product page loaded successfully.");
            }


        }
    }

