using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;
using System;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            //abrindo a pagina
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            
            //executadndo a processo
            driver.FindElement(By.CssSelector("input[class='search_query form-control ac_input']")).SendKeys("faded");
            driver.FindElement(By.CssSelector("input[class='search_query form-control ac_input']")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[@class='button ajax_add_to_cart_button btn btn-default']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@class='clearfix']/div[@class='layer_cart_cart col-xs-12 col-md-6']/div[@class='button-container']/a[@class='btn btn-default button button-medium']")).Click();
            driver.FindElement(By.XPath("//div[@id='center_column']/p[2]/a/span")).Click();
            driver.FindElement(By.XPath("//input[@id='email']")).SendKeys("renancarvalhos32@gmail.com");
            driver.FindElement(By.XPath("//input[@id='passwd']")).SendKeys("123456789");
            driver.FindElement(By.XPath("//button[@id='SubmitLogin']")).Click();
            driver.FindElement(By.XPath("//button[@name='processAddress']")).Click();
            driver.FindElement(By.XPath("//div[@id='uniform-cgv']/span/input")).Click();
            driver.FindElement(By.XPath("//button[@name='processCarrier']")).Click();
            driver.FindElement(By.XPath("//a[@class='bankwire']")).Click();
            driver.FindElement(By.XPath("//p[@id='cart_navigation']/button/span")).Click();  
            driver.FindElement(By.XPath("//a[@class='account']")).Click();                      
            driver.FindElement(By.XPath("//span[contains(text(),'Order history and details')]")).Click();
            driver.FindElement(By.XPath("//table[@id='order-list']/tbody/tr[@class='first_item ']/td[@class='history_link bold footable-first-column']/a[@class='color-myaccount']")).Click();   
            Thread.Sleep(3000);
            var ordem = driver.FindElement(By.XPath("//div[@id='block-order-detail']")).Text;
             
            //criando documento de texto
            string file = @"dados_da_ordem.txt";
            using (TextWriter writer = File.CreateText(file))
            {
                writer.WriteLine(ordem); 
            }
           driver.Quit();

        }
    }
}
