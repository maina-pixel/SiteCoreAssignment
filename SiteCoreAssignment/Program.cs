using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace SiteCoreAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            try
            {
                // Step 1: User arrives at Amazon's main page
                // *******************************************
                HomePage homePage = new HomePage(driver);
                homePage.GoTo("https://www.amazon.com/");

                System.Threading.Thread.Sleep(10000);

                // Step 2: Perform a search
                // ******************************************
                homePage.EnterTextInSearchBox("Laptop");
                homePage.ClickSearchButton();

                // Wait for search results to load
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
               

                // Select the first result (index 0)
                int selectedIndex = 0;
                IList<IWebElement> resultLinks = driver.FindElements(By.CssSelector(".s-main-slot .s-result-item a"));
                if (resultLinks.Count > selectedIndex)
                {
                   Console.WriteLine($"Selected index: {selectedIndex}");
                   resultLinks[selectedIndex].Click();
                   string priceText = driver.FindElement(By.CssSelector(".a-price .a-offscreen")).Text;
                    decimal price;

                    if (decimal.TryParse(priceText.Trim('$', ' '), NumberStyles.Currency, CultureInfo.InvariantCulture, out price))
                    {
                        // Assert that the price is more than 100
                        if (price > 100)
                        {
                            Console.WriteLine($"Price: ${price} is more than 100.");
                        }
                        else
                        {
                            Console.WriteLine($"Price: ${price} is not more than 100.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unable to parse price.");
                    }
 
                }
                else
                {
                    Console.WriteLine("No result links found or the selected index is out of range.");
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                
                driver.Quit();
            }
        }
    }
}
