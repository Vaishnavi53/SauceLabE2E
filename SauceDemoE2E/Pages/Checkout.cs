using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoE2E.Pages
{
    public class Checkout
    {
        private IWebDriver driver;

        public Checkout(IWebDriver driver)
        {

            this.driver = driver;
        }
        //locators on checkout page

        By checkoutbtn = By.XPath("//button[@id='checkout']");
        By itemincart = By.XPath("//div[@class='inventory_item_name']");
        By checkOutFirstName = By.XPath("//input[@id='first-name']");
        By checkOutLastName = By.XPath("//input[@id='last-name']");
        By checkOutPostalCode = By.XPath("//input[@id='postal-code']");
        By infotitle = By.XPath("//span[@class='title']");
        By continueCheckOut = By.XPath("//input[@id='continue']");
        By finishButton = By.XPath("//button[@id='finish']");
        string expectedtext = "Checkout: Your Information";


        // Getter to expose the locator
        public By getinfoTitleLocator()
        {
            return infotitle;
        }
        public void checkitemisincart()
        {
            IWebElement itemisincart = driver.FindElement(itemincart);
            if (itemisincart.Displayed)
            {
                Console.WriteLine("Added item is in the cart");
            }
            else
            {
                Console.WriteLine("Item is not added to teh cart");
            }
        }
        public void checkout()
        {
            driver.FindElement(checkoutbtn).Click();
        }
        public void details(String firstName, String lastName, String postalCode)
        {
            driver.FindElement(checkOutFirstName).SendKeys(firstName);
            driver.FindElement(checkOutLastName).SendKeys(lastName);
            driver.FindElement(checkOutPostalCode).SendKeys(postalCode);
        }

        public bool IsOnPage(string expectedText, By infotitle)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until(d => d.FindElement(infotitle));

                return element.Text.Contains(expectedText);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void finalcheckout()
        {
            driver.FindElement(continueCheckOut).Click();
        }
        public void finish()
        {

            IWebElement finishButton = driver.FindElement(By.Id("finish"));

            // Scroll the Finish button into view
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", finishButton);

            Thread.Sleep(1000); // Small wait to ensure scrolling is completed

            // Click the button
            finishButton.Click();
        }

        public void messagedisplay(string expectedmsg)
        {
            // Find the element containing the thank you message
            IWebElement thankYouElement = driver.FindElement(By.XPath("//h2[normalize-space()='Thank you for your order!']"));

            // Get the actual text from the element
            string actualMessage = thankYouElement.Text;

            // Verify the message using NUnit Assertion
            Assert.That(actualMessage, Is.EqualTo(expectedmsg), "The Thank You message did not match!");

        }
    }

}
