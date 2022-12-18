using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Twitter_Webscraper
{
    class Webscraper
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Twitter @ to see details of: ");
            var searchTerm = Console.ReadLine();
            var fullLink = "https://twitter.com/" + searchTerm;

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(fullLink);
            Thread.Sleep(7500);
            var name = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/div/div/div[3]/div/div/div/div/div[2]/div[1]/div/div[1]/div/div/span[1]/span"));
            var following = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/div/div/div[3]/div/div/div/div/div[5]/div[1]/a/span[1]/span"));
            var followers = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/div/div/div[3]/div/div/div/div/div[5]/div[2]/a/span[1]/span"));
            var latestTweet = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/main/div/div/div/div/div/div[3]/div/div/section/div/div/div[1]/div/div/div/article/div/div/div/div[2]/div[2]/div[2]/div[1]/div/span"));

            Console.WriteLine("----- User Info -----");
            Console.WriteLine("Username: " + name.Text);
            Console.WriteLine("Following: " + following.Text);
            Console.WriteLine("Followers: " + followers.Text + '\n');
            Console.WriteLine("----- Latest Tweet -----");
            Console.WriteLine(latestTweet.Text);
        }
    };
}