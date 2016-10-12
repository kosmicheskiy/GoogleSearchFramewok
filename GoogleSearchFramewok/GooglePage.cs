using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace GoogleSearchFramewok
{
    public class GooglePage
    {
        private IWebDriver driver;

        private string BaseAdress { get { return "https://www.google.com/ncr"; } }

        [FindsBy(How = How.XPath, Using = "//input[@name='q']")]
        private IWebElement searchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='rso']/div/div/div[4]/div/h3/a")]
         IWebElement resultTitle { get; set; }

        public GooglePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Open()
        {            
            driver.Navigate().GoToUrl(BaseAdress);           
        }      
             
        public void Search(string textToFind)
        {            
            searchInput.SendKeys(textToFind + Keys.Enter);
                       
        }

        public bool DoesSearchingResultContainsText(string textToFind, string expectedText)
        {          
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until( dr => {                    
                    return
                    ((IJavaScriptExecutor)dr)
                    .ExecuteScript("return document.readyState")
                    .Equals("complete");                    
                });
               
            if (string.IsNullOrWhiteSpace(textToFind) || string.IsNullOrWhiteSpace(expectedText))
                return false;

            if (textToFind.Contains(expectedText))
                return true;

            return false;
        }

        public bool DoesSearchingResultContainsTextAtIndex(string textToFind, string expectedText, int index)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until(ExpectedConditions.
                    PresenceOfAllElementsLocatedBy(By.CssSelector(".r>a")));

            var results = Driver.Instance.FindElements(By.CssSelector(".r>a"));
            
            if (results.Count < 1)               
                return false;

            if (index < 1)                
                return false;

            if (string.IsNullOrWhiteSpace(textToFind) || string.IsNullOrWhiteSpace(expectedText))                
                return false;

            if (results[index - 1].Text.Contains(expectedText))                 
                return true;
                      
            
            
            return false;
        }
    }
}
