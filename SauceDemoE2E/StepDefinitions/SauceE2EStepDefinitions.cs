using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoE2E.Pages;
using TechTalk.SpecFlow;

namespace SauceDemoE2E.StepDefinitions
{
    [Binding]
    public class SauceE2EStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        public AddToCartPage _addtocartpage;
        public LoginPage _loginPage;
        public AddToCartPage _addtocart;
        public Checkout _checkout;
        public SauceE2EStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];

            // Initialize pages with WebDriver
            _addtocartpage = new AddToCartPage(_driver);
            _loginPage = new LoginPage(_driver);
            _addtocart = new AddToCartPage(_driver);
            _checkout= new Checkout(_driver);
        }

        //[Test, Order(1)]
        [Given(@"user is on the login page")]
        public void GivenUserIsOnTheLoginPage()
        {
            _loginPage.launchbrowser();
        }

        [When(@"user enters the ""([^""]*)"" and ""([^""]*)"" in the text fields")]
        public void WhenUserEntersTheAndInTheTextFields(string p0, string p1)
        {
            _loginPage.enterusernamepass(p0, p1);   
        }

        [When(@"user clicks submit button")]
        public void WhenUserClicksSubmitButton()
        {
            _loginPage.submit();
        }

        [Then(@"user is navigated to home page")]
        public void ThenUserIsNavigatedToHomePage()
        {
            _addtocart.clickproductwanted();
        }

        //[Test,Order(2)]
        [Given(@"Given the user is logged in")]
        public void GivenGivenTheUserIsLoggedIn()
        {
            _loginPage.homepagedisplay();
        }

        [When(@"the user clicks the product wants")]
        public void WhenTheUserClicksTheProductWants()
        {
            _addtocart.clickproductwanted();
        }

        [When(@"user clicks the add to cart button")]
        public void WhenUserClicksTheAddToCartButton()
        {
            _addtocart.AddToCart(); 
        }

        [When(@"user clicks cart icon")]
        public void WhenUserClicksCartIcon()
        {
            _addtocart.clickcart();
        }

        [Then(@"cart should show the product added")]
        public void ThenCartShouldShowTheProductAdded()
        {
            _checkout.checkitemisincart();
        }

        //[Test,Order(3)]
        [Given(@"user is in chcekout page")]
        public void GivenUserIsInCheckoutInfoPage()
        {
            bool isOnPage = _checkout.IsOnPage("Checkout: Your Information",_checkout.getinfoTitleLocator());
            if(!isOnPage)
        {
                Console.WriteLine("Error: The user is NOT on the Checkout Page!");
            }

          
        }


        [When(@"user proceeds to checkout")]
        public void WhenUserProceedsToCheckout()
        {
            _checkout.checkout();
        }
        [When(@"enters ""([^""]*)""  ""([^""]*)"" and ""([^""]*)""")]
        public void WhenEntersAnd(string p0, string p1, string p2)
        {
            _checkout.details(p0, p1, p2);
        }


        [When(@"user continues by clicking continue")]
        public void WhenUserContinuesByClickingContinue()
        {
            _checkout.finalcheckout();
        }

        [When(@"user click finish")]
        public void WhenUserClickFinish()
        {
            _checkout.finish();
        }

        [Then(@"the message Thank you for your order! should be displayed")]
        public void ThenTheMessageThankYouForYourOrderShouldBeDisplayed()
        {
        
         _checkout.messagedisplay("Thank you for your order!") ;
        }
    }
}
