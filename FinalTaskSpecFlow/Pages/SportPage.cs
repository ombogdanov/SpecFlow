using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask_BBC2_Bogdanov.Pages
{
    public class SportPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//ul[contains(@class,'list')]//a[contains(@data-stat-title,'Football')]")]
        private IWebElement fottballButton;
        [FindsBy(How = How.XPath, Using = @"//ul[contains(@id,'sp-nav-secondary')]//a[contains(@href,'scores-fi')]")]
        private IWebElement scoresAdnFixtures;

        public SportPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement getFottballButton()
        {
            return fottballButton;
        }
        public ScorePage goToScorePage()
        {
            waitUntilEnable(timeToWait, scoresAdnFixtures);
            scoresAdnFixtures.Click();
            return new ScorePage(driver);
        }
    }
}
