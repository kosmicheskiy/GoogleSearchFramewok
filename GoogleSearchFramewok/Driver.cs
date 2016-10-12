using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace GoogleSearchFramewok
{
    public class Driver
    {
        public static IWebDriver Instance { get; private set; }       

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Window.Maximize();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));        
        }

        public static void Close() {
            Instance.Close();
        }




    }
}
