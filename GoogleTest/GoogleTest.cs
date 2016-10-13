using System;
using NUnit.Framework;
using GoogleSearchFramewok;

namespace GoogleTest
{
    [TestFixture]
    public class GoogleTest : TestSettings
    {
        //Test for ensuring 4th google search "Selenium IDE export to C#" result
        //contains text "Selenium IDE"
        [Test]
        public void GoogleSearchTest()
        {
            //Arrange 
            string textToFind = "Selenium IDE export to C#";
            string expectedText = "Selenium IDE";
            GooglePage page = new GooglePage(Driver.Instance);

            //Act
            page.Open();
            page.Search(textToFind);

            //Assert
            Assert.IsTrue(page.DoesSearchingResultContainsText(textToFind, expectedText),
                "The search result did not contains Selenium IDE phrase");
            
        }

        //2 
        //Generic test for ensuring result at index of google search "Selenium IDE export to C#" 
        //contains text "Selenium IDE"  
        [Test]
        public void GoogleSearchAtIndexTest()
        {
            //Arrange 
            string textToFind = "Selenium IDE export to C#";
            string expectedText = "Selenium IDE";
            int index = 4;
            GooglePage page = new GooglePage(Driver.Instance);

            //Act
            page.Open();
            page.Search(textToFind);

            //Assert
            Assert.IsTrue(page.DoesSearchingResultContainsTextAtIndex(textToFind, expectedText, index),
                "The search result did not contains Selenium IDE phrase at index {0}", index);

        }

        [Test]
        public void ATest() {
            Console.WriteLine(TestContext.CurrentContext);
        }
    }
}
