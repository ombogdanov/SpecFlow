using FinalTask_BBC2_Bogdanov.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTaskSpecFlow.Pages
{
    public class TeamScorePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//div[contains(@class,'sp-c-fixture__wrapper')]//span[contains(@class,'sp-c-fixture__block')]")]
        private IList<IWebElement> listScores;
        [FindsBy(How = How.XPath, Using = @"//div[contains(@class,'sp-c-fixture__wrapper')]//span[contains(@class,'gs-u-display-none')]")]
        private IList<IWebElement> listTeams;
        
        public TeamScorePage(IWebDriver driver) : base(driver)
        {
        }

       public string getTeamScoreStringToCheck()
        {
            return listTeams[0].Text + " " + listScores[0].Text + " : " + listScores[1].Text + " " + listTeams[1].Text;
        }
    }
}
