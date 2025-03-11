using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace SauceDemoSpec.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private static IWebDriver driver;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Setting up WebDriver before TestRun");
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver(); // Assigning to static driver
            TestContext.Progress.WriteLine("WebDriver initialized in BeforeTestRun");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Cleaning up WebDriver after TestRun");
            driver?.Quit();
            driver?.Dispose();
            TestContext.Progress.WriteLine("WebDriver cleaned up in AfterTestRun");
        }

        [BeforeScenario]
        public void Setup()
        {
            Console.WriteLine("Running before every scenario");
            _scenarioContext["WebDriver"] = driver; // Using the static driver
        }

        [AfterScenario]
        public void TearDown()
        {
            Console.WriteLine("Running after every scenario");
            var scenarioDriver = _scenarioContext["WebDriver"] as IWebDriver;
            //scenarioDriver?.Quit();  // Cleanup after each scenario
            //scenarioDriver?.Dispose();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            Console.WriteLine("Running before step");
        }

        [AfterStep]
        public void AfterStep()
        {
            Console.WriteLine("Running after step");
        }

        //[AfterFeature]
        //public void AfterFeature()
        //{
        //    driver?.Quit();
        //    driver?.Dispose();
        //}
    }
}

