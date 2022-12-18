using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ICTJob_Webscraper
{
    class Webscraper
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a searchterm for a job: ");
            var searchTerm = Console.ReadLine();
            searchTerm = searchTerm.Replace(' ', '+');
            var fullLink = "https://www.ictjob.be/nl/it-vacatures-zoeken?keywords=" + searchTerm;

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(fullLink);
            Thread.Sleep(10000);
            var titles = driver.FindElements(By.ClassName("job-title"));
            var companies = driver.FindElements(By.ClassName("job-company"));
            var locations = driver.FindElements(By.XPath("//span[@itemprop='addressLocality']"));
            var links = driver.FindElements(By.XPath("//a[@class='job-title search-item-link']"));
            var keywords = driver.FindElements(By.ClassName("job-keywords"));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("-----Job " + (i + 1) + "-----");
                Console.WriteLine("Title: " + titles[i*2].Text);
                Console.WriteLine("Company: " + companies[i].Text);
                Console.WriteLine("Location: " + locations[i].Text);
                Console.WriteLine("Keywords: " + keywords[i].Text);
                Console.WriteLine("Link: " + links[i].GetAttribute("href") + '\n');
            }
        }
    };
}