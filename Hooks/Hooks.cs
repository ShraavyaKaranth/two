using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject.Hooks
{
    //[Binding]
    internal class Hooks
    {
        private ScenarioContext _scenarioContext;

        public IWebDriver driver;
        public Hooks(ScenarioContext scenarioContext)
        {

            _scenarioContext = scenarioContext;

        }

        public void openBrowser(string browserName)
        {
            if (browserName == "firefox")
            {
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                IWebDriver firefoxDriver = new FirefoxDriver();
                _scenarioContext["WebDriver"] = firefoxDriver;
            }
            else if (browserName == "edge")
            {
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                IWebDriver edgeDriver = new EdgeDriver();
                _scenarioContext["WebDriver"] = edgeDriver;
            }
            else if (browserName == "chrome")
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                IWebDriver chromeDriver = new ChromeDriver();
                _scenarioContext["WebDriver"] = chromeDriver;
            }
        }
        [BeforeScenario]
        public void Setup()
        {

            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //IWebDriver firefoxDriver = new FirefoxDriver();
            //_scenarioContext["WebDriver"] = firefoxDriver;
            //Console.WriteLine("Running before every scenario");


            try
            {
                Console.WriteLine("Initializing Edge browser in headless mode...");
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());

                // Configure EdgeOptions for headless mode
                var edgeOptions = new EdgeOptions();
                edgeOptions.AddArgument("headless"); // Enables headless mode
                edgeOptions.AddArgument("disable-gpu"); // Disables GPU acceleration (optional)
                edgeOptions.AddArgument("window-size=1920,1080"); // Sets the browser window size (optional)

                // Initialize EdgeDriver with the configured options
                IWebDriver edgeDriver = new EdgeDriver(edgeOptions);

                // Store the WebDriver in ScenarioContext for reuse
                _scenarioContext["WebDriver"] = edgeDriver;
                Console.WriteLine("Edge browser initialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing Edge browser: {ex.Message}");
                throw;
            }
        }
        [AfterScenario]
        public void TearDown()
        {

            Console.WriteLine("Running after every scenario");
            var driver = _scenarioContext["WebDriver"] as IWebDriver;
            driver?.Quit();
            driver?.Dispose();

        }


        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            TestContext.Progress.WriteLine("Running before TestRun");

        }


        [AfterTestRun]
        public static void AfterTestRun()
        {


            TestContext.Progress.WriteLine("Running after TestRun");


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
    }
}