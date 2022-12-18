using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace YouTube_Webscraper
{
    class Webscraper
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a searchterm: ");
            var searchTerm = Console.ReadLine();
            searchTerm = searchTerm.Replace(' ', '+');
            var fullLink = "https://www.youtube.com/results?search_query=" + searchTerm + "&sp=CAI%253D";

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(fullLink);
            Thread.Sleep(5000);
            var titles = driver.FindElements(By.Id("video-title"));
            var views = driver.FindElements(By.XPath("//*[@id=\"metadata-line\"]/span[1]"));
            var channels = driver.FindElements(By.XPath("//*[@id=\"text\"]/a"));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("-----Video " + (i + 1) + "-----");
                Console.WriteLine("Title: " + titles[i].Text);
                Console.WriteLine("Views: " + views[i].Text);
                Console.WriteLine("Channel: " + channels[(1 + i * 2)].Text);
                Console.WriteLine("Link: " + titles[i].GetAttribute("href") + '\n');
            }
        }
    };
}