using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace UITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int waitingTime = 2000;
            By SearchClick = By.LinkText("Click");
            By SearchTextInput = By.LinkText("Text Input");
            By ProgressBar = By.LinkText("Progress Bar");
            By SampleApp = By.LinkText("Sample App");
            By ScrollBars = By.LinkText("Scrollbars");
            By OverElement = By.LinkText("Overlapped Element");


            By ClickBadButton = By.Id("badButton");
            By ClickNewButtonName = By.Id("newButtonName");
            By UpdateButton = By.Id("updatingButton");

            By Username = By.Name("UserName");
            By PassWord = By.Name("Password");
            By LoginBTN = By.Id("login");

            By StartButton = By.Id("startButton");
            By StopButton = By.Id("stopButton");


            By OverElemButton1 = By.Id("id");
            By OverElemButton2 = By.Id("name");

            IWebDriver webDriver = new ChromeDriver();

            webDriver.Manage().Window.Maximize();


            Thread.Sleep(waitingTime);
            webDriver.Navigate().GoToUrl("http://localhost:3000");
            Thread.Sleep(waitingTime);

            //Click
            webDriver.FindElement(SearchClick).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(ClickBadButton).Click();

            Thread.Sleep(waitingTime);
            webDriver.Navigate().GoToUrl("http://localhost:3000");
            Thread.Sleep(waitingTime);

            //Text Input
            webDriver.FindElement(SearchTextInput).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(ClickNewButtonName).SendKeys("My Really Really Cool Button Name");
            Thread.Sleep(waitingTime);
            webDriver.FindElement(UpdateButton).Click();
            Thread.Sleep(waitingTime);

            webDriver.Navigate().GoToUrl("http://localhost:3000");
            Thread.Sleep(waitingTime);

            //Sample App
            webDriver.FindElement(SampleApp).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(Username).SendKeys("Cool Username");
            Thread.Sleep(waitingTime);
            webDriver.FindElement(PassWord).SendKeys("pwd");
            Thread.Sleep(waitingTime);
            webDriver.FindElement(LoginBTN).Click();
            Thread.Sleep(waitingTime);

            webDriver.Navigate().GoToUrl("http://localhost:3000");
            Thread.Sleep(waitingTime);

            //Progress Bar
            webDriver.FindElement(ProgressBar).Click();
            Thread.Sleep(waitingTime);
            webDriver.FindElement(StartButton).Click();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.PollingInterval = TimeSpan.FromMilliseconds(10);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='progress-bar bg-info'][contains(@style,'width: 75%')]")));
            webDriver.FindElement(StopButton).Click();
            Thread.Sleep(waitingTime);


            webDriver.Navigate().GoToUrl("http://localhost:3000");
            Thread.Sleep(waitingTime);

            //Scrollbars
            webDriver.FindElement(ScrollBars).Click();
            Thread.Sleep(waitingTime);

            WebElement element = (WebElement)webDriver.FindElement(By.Id("hidingButton"));
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(element);
            actions.Perform();
            Thread.Sleep(waitingTime);

            webDriver.Navigate().GoToUrl("http://localhost:3000");
            Thread.Sleep(waitingTime);

            //OverLapped Element
            webDriver.FindElement(OverElement).Click();
            Thread.Sleep(waitingTime);

            webDriver.FindElement(OverElemButton1).SendKeys("Overlapped");
            Thread.Sleep(waitingTime);
           
            var elementAtDown = webDriver.FindElement(By.Id("name"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            //This will scroll the page till the element is found   
            js.ExecuteScript("arguments[0].scrollIntoView();", elementAtDown);
            //This will scroll the web page till end.       
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(waitingTime);

            webDriver.FindElement(OverElemButton2).SendKeys("Element");
            Thread.Sleep(waitingTime);

            webDriver.Quit();
        }
    }
}
