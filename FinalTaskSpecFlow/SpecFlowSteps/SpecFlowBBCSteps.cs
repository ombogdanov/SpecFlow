using FinalTask_BBC2_Bogdanov.SpecFlowSteps;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace FinalTaskSpecFlow.SpecFlowSteps
{
    [Binding]
    public class SpecFlowBBCSteps : BaseStepDefinitions
    {
        [Given(@"User goes to bbc main page")]
        public void GivenUserGoesToBbc_Com()
        {
            homePage = new FinalTask_BBC2_Bogdanov.Pages.HomePage(driver);
        }

        [When(@"User clicks news button")]
        public void WhenUserClicksNewsButton()
        {
            newsPage = homePage.goToNewsPage();
        }

        [Then(@"User can see main news equals (.*)")]
        public void ThenUserCanSeeMainNewsEquals(string mainArticleName)
        {
            Assert.IsTrue(newsPage.GetMainArticlString().ToLower().Contains(mainArticleName.ToLower()));
        }

        [Given(@"User goes to sport page")]
        public void GivenUserGoesToSportPage()
        {
            sportPage = homePage.goToSportPage();
        }

        [Given(@"User navigates to Football")]
        public void GivenUserNavigatesToFootball()
        {
            sportPage.getFottballButton().Click();
        }

        [Given(@"User navigates to Scores & Fixtures page")]
        public void GivenUserNavigatesToScoresFixturesPage()
        {
            scorePage = sportPage.goToScorePage();
        }


        [Given(@"User enter the name of the ""(.*)"" in searchInput")]
        public void GivenEnterTheNameOfTheInSearchInput(string p0)
        {
            scorePage.enterChempionshipInput(p0);
            scorePage.getSearchInputForClick().Click();
        }

        [When(@"User click on the date  ""(.*)"" and ""(.*)""")]
        public void WhenIClickOnTheDateAnd(string p0, string p1)
        {
            scorePage.getYearMonthElementToClick(p1, p0).Click();
        }

        [Then(@"User can see scores of the ""(.*)"" - ""(.*)"" and ""(.*)"" - ""(.*)""")]
        public void ThenICanSeeScoresOfThe_And_(string p0, string p1, string p2, string p3)
        {
            Assert.IsTrue(scorePage.getScoreTeamElement(p0 + " " + p1 + " : " + p3 + " " + p2));
        }

        [Given(@"User click on the date  ""(.*)"" and ""(.*)""")]
        public void GivenUserClickOnTheDateAnd(string p0, string p1)
        {
            scorePage.getYearMonthElementToClick(p1, p0).Click();
        }

        [When(@"User click on the scores of the ""(.*)"" - ""(.*)"" and ""(.*)"" - ""(.*)""")]
        public void WhenUserClickOnTheScoresOfThe_And_(string p0, int p1, string p2, int p3)
        {
            teamScorePage = scorePage.toGoTeamScorePage(scorePage.getScoreTeamElement(p0 + " " + p1 + " : " + p3 + " " + p2, true));
        }

        [Then(@"User can see the same scores of the ""(.*)"" - ""(.*)"" and ""(.*)"" - ""(.*)""")]
        public void ThenUserCanSeeTheSameScoresOfThe_And_(string p0, int p1, string p2, int p3)
        {
            Assert.AreEqual(teamScorePage.getTeamScoreStringToCheck(), p0 + " " + p1 + " : " + p3 + " " + p2);
        }

        [Then(@"User can see the seconds articls name is")]
        public void ThenUserCanSeeTheSecondsArticlsNameIs(Table table)
        {
            newsPage.ShowSecondArticls();
            Assert.IsTrue(newsPage.IsTrueSecond(newsPage.TableToList(table)));
        }


    }
}
