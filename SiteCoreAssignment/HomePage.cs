using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SiteCoreAssignment
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Elements on the Home page
        public void GoTo(string url)
        {
            driver.Navigate().GoToUrl(url);


        }

        public void EnterTextInSearchBox(string searchText)
        {
            //System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(searchText);
        }

        public void ClickSearchButton()
        {
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();

        }
    }

}
    





   