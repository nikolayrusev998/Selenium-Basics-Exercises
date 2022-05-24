using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumAutomatedTestsExercises
{
    public class SeleniumAutomatedTestsExercises
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void setUp() 
        {
            driver = new ChromeDriver();

        }
      
        [Test]
        public void Test_SearchLink()
        {
            
            driver.Url = "https://wikipedia.org";
            var searchInput = driver.FindElement(By.Id("searchInput")) ; 
            searchInput.SendKeys("QA" + Keys.Enter);
          

            Assert.That(driver.Url.Equals("https://en.wikipedia.org/wiki/QA"));
           

        }

        [Test]
        public void Test_SumOfTwoNums() 
        {
            driver.Url = "https://sum-numbers.nakov.repl.co";

            var firstTextField = driver.FindElement(By.Id("number1"));
            var secondTextField = driver.FindElement(By.Id("number2"));
            var calcBtn = driver.FindElement(By.Id("calcButton"));
            var resetBtn = driver.FindElement(By.Id("resetButton"));
            

            firstTextField.SendKeys("15");
            secondTextField.SendKeys("7");
            
            calcBtn.Click();
            var result = driver.FindElement(By.Id("result")).Text;
            Assert.That(result, Is.EqualTo("Sum: 22"));


        }

        [Test]
        public void Test_SumOfTwoNums_InvalidInput()
        {
            driver.Url = "https://sum-numbers.nakov.repl.co";
            driver.FindElement(By.Id("number1")).SendKeys("hello");
            driver.FindElement(By.Id("number2")).SendKeys("");
            driver.FindElement(By.Id("calcButton")).Click();
            var resultText = driver.FindElement(By.Id("result")).Text;
            Assert.That(resultText, Is.EqualTo("Sum: invalid input"));


        }
        [Test]
        public void Test_SumOfTwoNums_Reset() 
        {
            driver.Url = "https://sum-numbers.nakov.repl.co";
            driver.FindElement(By.Id("number1")).SendKeys("hello");
            driver.FindElement(By.Id("number2")).SendKeys("");
            driver.FindElement(By.Id("calcButton")).Click();
            var num1Text = driver.FindElement(By.Id("number1"));
            var num1TextValue = num1Text.GetAttribute("value");
            var num2Text = driver.FindElement(By.Id("number1"));
            var num2TextValue = num2Text.GetAttribute("value");

            Assert.IsNotEmpty(num1TextValue);
            Assert.IsNotEmpty(num2TextValue);

            driver.FindElement(By.Id("resetButton")).Click();
            var num1EmptyText = driver.FindElement(By.Id("number1"));
            var num1EmpltyValue = num1Text.GetAttribute("value");
            var num2EmptyText = driver.FindElement(By.Id("number2"));
            var num2EmpltyValue = num1Text.GetAttribute("value");


            Assert.IsEmpty(num1EmpltyValue);
            Assert.IsEmpty(num2EmpltyValue);


        }

        [Test]
        public void Test_URLShortener_HomePageTitle() 
        {
            driver.Url = " https://shorturl.nakov.repl.co";
            Assert.That(driver.Title.Contains("URL Shortener"));

        }

        [Test]
        public void Test_URLShortener_ShortURLs() 
        {
            driver.Url = "https://shorturl.nakov.repl.co/urls";
            Assert.That(driver.Title.Contains("Short URLs"));
            var firstCell = driver.FindElement(By.XPath("/html/body/main/table/tbody/tr[1]/td[1]/a"));
            var secondCell = driver.FindElement(By.XPath("/html/body/main/table/tbody/tr[1]/td[2]/a"));

            Assert.That(firstCell.GetAttribute("text"), Is.EqualTo("https://nakov.com"));
            Assert.That(secondCell.GetAttribute("text"), Is.EqualTo("http://shorturl.nakov.repl.co/go/nak"));
        }
  //      [Test]
        public void Test_URLShortener_AddURL()
        {
            driver.Url = "https://shorturl.nakov.repl.co/add-url";

            driver.FindElement(By.Id("url")).SendKeys("asjdajsdjasd");
            driver.FindElement(By.CssSelector("body > main > form > table > tbody > tr:nth-child(3) > td > button")).Click();
            // Invalid data;
            Assert.That(driver.FindElement(By.CssSelector(".err")).Text, Is.EqualTo("Invalid URL!"));
        }

       /* [Test]
        public void Test_URLShortener_VisitURL() 
        {
            driver.Url = "https://shorturl.nakov.repl.co/urls";
            driver.FindElement(By.XPath("/html/body/main/table/tbody/tr[1]/td[2]/a")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Assert.That(driver.FindElement(By.XPath("/html/body/main/table/tbody/tr[1]/td[4]")), Is.EqualTo(driver.FindElement(By.XPath("/html/body/main/table/tbody/tr[1]/td[4]")).GetAttribute("text" + 1);



        }*/

        [OneTimeTearDown]
        public void tearDown() 
        {
            driver.Quit();
        }
    }
}