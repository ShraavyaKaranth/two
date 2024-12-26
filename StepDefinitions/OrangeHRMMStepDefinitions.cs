using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using specflowNEW.Pages;
using specflowNEW.Utils;
using TechTalk.SpecFlow;

namespace specflowNEW.StepDefinitions
{
    [Binding]
    public class OrangeHRMStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        public IWebDriver _driver;
        LoginPage loginpage;

        //public OrangeHRMStepDefinitions(ScenarioContext scenarioContext)
        //{

        //    _scenarioContext = scenarioContext;
        //    _driver = _scenarioContext["WebDriver"] as IWebDriver;

        //}

        public OrangeHRMStepDefinitions()
        {
            //var options = new FirefoxOptions();
            //options.AddArgument("--headless");
            //options.AddArgument("--window-size=1920,1080");

            //_driver = new FirefoxDriver("C:\\Users\\shkar\\Downloads\\geckodriver-v0.35.0-win32", options);
            var options = new EdgeOptions();
            options.AddArgument("headless"); // Enable headless mode
            options.AddArgument("disable-gpu"); // Disable GPU acceleration
            options.AddArgument("window-size=1920,1080"); // Set window size for consistency
            options.AddArgument("disable-extensions"); // Disable browser extensions
            options.AddArgument("no-sandbox"); // Required for certain environments
            options.AddArgument("disable-dev-shm-usage"); // Overcome limited resource problems

            _driver = new EdgeDriver(options);
        }


        [Given(@"User is on the orange hrm login page")]
        public void GivenUserIsOnTheOrangeHrmLoginPage()
        {
            //loginpage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            //loginpage.launchbrowser();
            _driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        [When(@"User enters the ""([^""]*)"" and ""([^""]*)"" in the text fields")]
        public void WhenUserEntersTheAndInTheTextFields(string usrname, string passwd)
        {

            //IWebElement username = _driver.FindElement(By.XPath("//input[@name = 'username']"));

            //username.SendKeys(usrname);


            //IWebElement password = _driver.FindElement(By.XPath("//input[@name = 'password']"));

            //password.SendKeys(passwd);
            loginpage = new LoginPage(_driver);

            loginpage.enterusernamepass(usrname, passwd);

        }

        [When(@"User clicks on submit button")]
        public void WhenUserClicksOnSubmitButton()
        {


            //IWebElement loginbutton = _driver.FindElement(By.XPath("//button[@type = 'submit']"));

            //loginbutton.Click();
            loginpage = new LoginPage(_driver);

            loginpage.submit();

            Thread.Sleep(1000);


        }

        [Then(@"User is navigated to home page")]
        public void ThenUserIsNavigatedToHomePage()
        {

            //IWebElement Admin = _driver.FindElement(By.XPath("(//a[@class = 'oxd-main-menu-item'])[1]"));

            //Admin.Click();
            loginpage = new LoginPage(_driver);

            loginpage.homepagedisplay();

        }

        [Then(@"User is on the home page and a error is displayed")]
        public void ThenUserIsOnTheHomePageAndAErrorIsDisplayed()
        {
            //_driver.Quit();
            //_driver.Dispose();
            _driver.Close();
            //throw new PendingStepException();
        }
    }
}