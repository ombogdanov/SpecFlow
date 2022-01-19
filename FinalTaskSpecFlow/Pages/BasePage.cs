using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace FinalTask_BBC2_Bogdanov.Pages
{

    public class BasePage
    {
        public IWebDriver driver;
        public double timeToWait = 30;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void implisityWait(double timeToWait)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
        }
        public IWebElement waitAndReturmElementExist(double timeToWait, string xpathElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            var element = wait.Until(x => x.FindElement(By.XPath(xpathElement)));
            return element;
        }

        public void waitUntilEnable(double timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until<bool>(x => element.Enabled);
        }


    }
}
