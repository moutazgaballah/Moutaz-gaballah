using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using expectedcondtions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace trainingAutomation
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContext;
        public TestContext TestContext
        {

            get { return testContext; }
            set { testContext = value; }

        }
        
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"D:\automation\trainingAutomation\trainingAutomation\data\login.csv", "login#csv", DataAccessMethod.Sequential)]
        public void TestMethod1()
        {
            //Sucessfull login 
            IWebDriver chrome = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromMinutes(1));
            chrome.Navigate().GoToUrl("https://www.facebook.com/");
            IWebElement EMail = chrome.FindElement(By.Id("email"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Id("email")));
            EMail.SendKeys(TestContext.DataRow["email"].ToString());
            IWebElement Password = chrome.FindElement(By.Id("pass"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Id("pass")));
            Password.SendKeys(TestContext.DataRow["password"].ToString());
            chrome.FindElement(By.Name("login")).Click();
            wait.Until(expectedcondtions.ElementIsVisible(By.CssSelector("div[role='main']")));
            Assert.IsTrue(chrome.PageSource.Contains("Welcome to Facebook"));
           // chrome.Close();

        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"D:\automation\trainingAutomation\trainingAutomation\data\login.csv", "login#csv", DataAccessMethod.Sequential)]
        public void TestMethod2()
        {
            //incorrect password 
            IWebDriver chrome = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromMinutes(1));
            chrome.Navigate().GoToUrl("https://www.facebook.com/");
            IWebElement EMail = chrome.FindElement(By.Id("email"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Id("email")));
            EMail.SendKeys(TestContext.DataRow["email"].ToString());
            IWebElement Password = chrome.FindElement(By.Id("pass"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Id("pass")));
            Password.SendKeys("Otv@1dddd");
            chrome.FindElement(By.Name("login")).Click();
            wait.Until(expectedcondtions.ElementIsVisible(By.Id("header_block")));
            Assert.IsTrue(chrome.PageSource.Contains("The password that you've entered is incorrect"));
          //  chrome.Close();

        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"D:\automation\trainingAutomation\trainingAutomation\data\registration.csv", "registration#csv", DataAccessMethod.Sequential)]
        public void TestMethod3()
        {
            //registration form
            IWebDriver chrome = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromMinutes(1));
            chrome.Navigate().GoToUrl("https://www.facebook.com/");
            IWebElement Create_account = chrome.FindElement(By.Id("u_0_2"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Id("u_0_2"))).Click();
            Create_account.Click();
            Thread.Sleep(5000);

            IWebElement firstname = chrome.FindElement(By.Name("firstname"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Name("firstname")));
            firstname.SendKeys(TestContext.DataRow["firstname"].ToString());

            IWebElement lastname = chrome.FindElement(By.Name("lastname"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Name("lastname")));
            lastname.SendKeys(TestContext.DataRow["surname"].ToString());

            IWebElement Email = chrome.FindElement(By.Name("reg_email__"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Name("reg_email__")));
            Email.SendKeys(TestContext.DataRow["email"].ToString());

            IWebElement ReEnterEmail = chrome.FindElement(By.Name("reg_email_confirmation__"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Name("reg_email_confirmation__")));
            ReEnterEmail.SendKeys(TestContext.DataRow["email2"].ToString());

            IWebElement password = chrome.FindElement(By.Id("password_step_input"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Id("password_step_input")));
            password.SendKeys(TestContext.DataRow["password"].ToString());

            IWebElement day = chrome.FindElement(By.Id("day"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Id("day")));
            day.SendKeys(TestContext.DataRow["day"].ToString());

            IWebElement month = chrome.FindElement(By.Id("month"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Id("month")));
            month.SendKeys(TestContext.DataRow["month"].ToString());

            IWebElement year = chrome.FindElement(By.Id("year"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Id("year")));
            year.SendKeys(TestContext.DataRow["year"].ToString());

            IWebElement gender = chrome.FindElement(By.XPath("//label[text()='"+ TestContext.DataRow["gender"].ToString()+"']"));
            gender.Click();

            IWebElement SignUp = chrome.FindElement(By.Name("websubmit"));
            wait.Until(expectedcondtions.ElementIsVisible(By.Name("websubmit")));
            SignUp.Click();
          

        }
    }
}
