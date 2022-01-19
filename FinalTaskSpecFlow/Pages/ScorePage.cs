using FinalTaskSpecFlow.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalTask_BBC2_Bogdanov.Pages
{
    public class ScorePage : BasePage
    {

        private string aInDivWithYearAndMounth = @"//a[contains(@class,'sp-c-date-picker-timeline__item-inner  false')]";
        private string searchInputForClick = @"//a//mark";



        [FindsBy(How = How.XPath, Using = @"//input[contains(@name,'search')]")]
        private IWebElement searchChempionshipInput;
        [FindsBy(How = How.XPath, Using = @"//div[@class = 'sp-c-date-picker-timeline__lists']")]
        private IWebElement divWithYearAndMounth;
        [FindsBy(How = How.XPath, Using = @"//span[contains(@class,'gel-long-primer-bold gs-u-display-block')]")]
        private IList<IWebElement> listOfMounth;
        [FindsBy(How = How.XPath, Using = @"//span[@class='gel-long-primer gs-u-display-block']")]
        private IList<IWebElement> listOfYears;
        [FindsBy(How = How.XPath, Using = @"//li[@class='gs-o-list-ui__item gs-u-pb-']")]
        private IList<IWebElement> listScoresAndTeams;
        [FindsBy(How = How.XPath, Using = @"//li[@class='gs-o-list-ui__item gs-u-pb-']//div/span/span/span")]
        private IList<IWebElement> listTeams;
        string listScoresAndTeams1 = @"//li[@class='gs-o-list-ui__item gs-u-pb-'][1]";

        private IWebElement yearMonthElement(string year, string mounth, IWebElement divWithYearAndMounth, string aInDivWithYearAndMounth)
        {

            IList<IWebElement> listOfAElementYearsMonth = divWithYearAndMounth.FindElements(By.XPath(aInDivWithYearAndMounth));
            foreach (var element in listOfAElementYearsMonth)
            {
                if ((element.Text.Contains(year)) && (element.Text.Contains(mounth)))
                {
                    return element;
                }
            }
            return null;
        }

        public ScorePage(IWebDriver driver) : base(driver)
        {            
        }


        public void enterChempionshipInput(string championShip)
        {
            searchChempionshipInput.SendKeys(championShip);
        }

        public IWebElement getSearchInputForClick()
        {
            return waitAndReturmElementExist(timeToWait, searchInputForClick);
        }

        public IWebElement getYearMonthElementToClick(string yearChempionShip, string mounthChempionShip)
        {
            return yearMonthElement(yearChempionShip, mounthChempionShip,divWithYearAndMounth, aInDivWithYearAndMounth);
        }

        public bool getScoreTeamsToCheck(String stringTeamsScores, string team1, string team2)
        {
            waitAndReturmElementExist(30, listScoresAndTeams1);
            IList<IWebElement> listOfTeams = listScoresAndTeams[0].FindElements(By.XPath("//li[@class='gs-o-list-ui__item gs-u-pb-']//div/span/span/span"));
            getScoreTeamElement(stringTeamsScores);
            for (var i = 0; i < listOfTeams.Count; i++)
            {
                if (listOfTeams[i].Text.ToLower().Contains(team1.ToLower()))
                {
                    if (listOfTeams[i+2].Text.ToLower().Contains(team2.ToLower()))
                    {
                        if ((listOfTeams[i].Text + " " + listOfTeams[i + 1].Text + " : " + listOfTeams[i + 3].Text + " " + listOfTeams[i + 2].Text) == stringTeamsScores) return true;
                    }
                }
            }
            return false;
        }

        public bool getScoreTeamElement(string stringTeamsScores)
        {
            waitAndReturmElementExist(30, listScoresAndTeams1);
            for (var i = 0; i < listTeams.Count(); i+=4)
            {
                string resultString = listTeams[i + 0].Text + " " + listTeams[i + 1].Text + " : " + listTeams[i + 3].Text + " " + listTeams[i + 2].Text;
                Console.WriteLine(resultString);
                if (resultString == stringTeamsScores)
                {
                    return true;
                }
            }
            return false;
        }
        public IWebElement getScoreTeamElement(string stringTeamsScores, bool returnWebElement)
        {
            waitAndReturmElementExist(30, listScoresAndTeams1);
            for (var i = 0; i < listTeams.Count(); i += 4)
            {
                string resultString = listTeams[i + 0].Text + " " + listTeams[i + 1].Text + " : " + listTeams[i + 3].Text + " " + listTeams[i + 2].Text;
                Console.WriteLine(resultString);
                if (resultString == stringTeamsScores)
                {
                    return listTeams[i];
                }
            }
            return null;
        }

        public TeamScorePage toGoTeamScorePage(IWebElement element)
        {
            element.Click();
            return new TeamScorePage(driver);
        }

    }
}
