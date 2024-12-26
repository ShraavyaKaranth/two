using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using specflowNEW.Utils;

namespace specflowNEW.Pages
{
    [Binding]
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {

            this.driver = driver;
        }

        // locators on thye login page

        By usernameField = By.XPath("//input[@name = 'username']");
        By passwordField = By.XPath("//input[@name = 'password']");
        By loginFormLocator = By.XPath("//button[@type = 'submit']");
        //By homepagedisplayed = By.XPath("//p[normalize-space()='Time at Work']");

        // laucnh browser

        public void launchbrowser()
        {
            driver.Navigate().GoToUrl(Config.BaseUrl);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        // enter username and password

        public void enterusernamepass(String username, String password)
        {

            driver.FindElement(usernameField).SendKeys(username);
            driver.FindElement(passwordField).SendKeys(password);

        }

        // submit method

        public void submit()
        {

            driver.FindElement(loginFormLocator).Click();

        }

        // home page is displayed

        public void homepagedisplay()
        {


            //IWebElement homepage = driver.FindElement(homepagedisplayed);

            //if (homepage.Displayed)
            //{
            //    Console.WriteLine("Home page is displayed");
            //}
            //else
            //{

            //    Console.WriteLine("Home page is not displayed");
            //}
            Console.WriteLine("Home Page");
            Thread.Sleep(3000);
            driver.Close();
        }
    }
}
