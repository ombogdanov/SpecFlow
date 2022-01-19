using FinalTask_BBC2_Bogdanov.Pages;
using FinalTaskSpecFlow.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace FinalTask_BBC2_Bogdanov.SpecFlowSteps
{
    public class BaseStepDefinitions
    {
        public IWebDriver driver;
        public HomePage homePage = null;
        public NewsPage newsPage = null;
        public SportPage sportPage = null;
        public ScorePage scorePage = null;
        public TeamScorePage teamScorePage = null;



        [Before]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Manage().Window.Maximize();
        }

        [After]
        public void Finish()
        {
            driver.Close();
        }
    }
}
