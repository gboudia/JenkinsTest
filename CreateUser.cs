using MyFirstProject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TestProject1;

namespace TestProject1
{
    public class Tests
    {
        public IWebDriver driver;
        IJavaScriptExecutor js;
        ReadData read = new ReadData();
        Client client;
        List<Client> clients;

        [SetUp]
        public void Debut()
        {
            driver = new ChromeDriver(@"C:\\Selenium\\chromedriver.exe");
            Console.WriteLine("je suis dans la methode Debut");
        }

        [Test]
        public void CreationClientHomme()
        {
            clients = read.ReadDataFromJson();
            js = (IJavaScriptExecutor)driver;
            client = clients[0];
            driver.Navigate().GoToUrl("https://sendform.nicepage.io/?version=13efcba7-1a49-45a5-9967-c2da8ebdd189&uid=f7bd60f0-34c8-40e3-8e2c-06cc19fcb730");
            driver.Manage().Window.Maximize();

            // Clique sur le bouton 'Homme'
            driver.FindElement(By.Id("field-2688")).Click();
            SelectElement select = new SelectElement(driver.FindElement(By.Id("select-9648")));
            select.SelectByValue("FR");
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("email-c6a3")));
            driver.FindElement(By.Id("email-c6a3")).SendKeys(client.Email);

            driver.FindElement(By.Id("name-c6a3")).SendKeys(client.Name);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("phone-84d9")));
            driver.FindElement(By.Id("phone-84d9")).SendKeys(client.Phone);

            driver.FindElement(By.Id("address-be2d")).SendKeys(client.Address);
            driver.FindElement(By.Id("message-c6a3")).SendKeys(client.Message);

            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("select-c283")));


            string genderSelected = driver.FindElement(By.Id("field-2688")).GetAttribute("value");
            string PaysSelected = select.SelectedOption.GetAttribute("value");
            SelectElement selectProduct = new SelectElement(driver.FindElement(By.Id("select-c283")));

            if (genderSelected == "man" && PaysSelected == "FR")
            {

                selectProduct.SelectByValue("mot");
                driver.FindElement(By.Id("checkbox-8214"));
            }
            else
            {
                selectProduct.SelectByValue("velo");
                driver.FindElement(By.Id("checkbox-3842"));


            }
        }

        [Test]
        public void CreationClientFemme()
        {
            clients = read.ReadDataFromJson();
            js = (IJavaScriptExecutor)driver;
            client = clients[1];
            driver.Navigate().GoToUrl("https://sendform.nicepage.io/?version=13efcba7-1a49-45a5-9967-c2da8ebdd189&uid=f7bd60f0-34c8-40e3-8e2c-06cc19fcb730");
            driver.Manage().Window.Maximize();

            // Clique sur le bouton 'Femme'
            driver.FindElement(By.Id("field-aa6c")).Click();
            SelectElement select = new SelectElement(driver.FindElement(By.Id("select-9648")));
            select.SelectByValue("IT");
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("email-c6a3")));
            driver.FindElement(By.Id("email-c6a3")).SendKeys(client.Email);

            driver.FindElement(By.Id("name-c6a3")).SendKeys(client.Name);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("phone-84d9")));
            driver.FindElement(By.Id("phone-84d9")).SendKeys(client.Phone);

            driver.FindElement(By.Id("address-be2d")).SendKeys(client.Address);
            driver.FindElement(By.Id("message-c6a3")).SendKeys(client.Message);

            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("select-c283")));
            string genderSelected = driver.FindElement(By.Id("field-2688")).GetAttribute("value");
            string PaysSelected = select.SelectedOption.GetAttribute("value");
            SelectElement selectProduct = new SelectElement(driver.FindElement(By.Id("select-c283")));

            if (genderSelected == "women" && PaysSelected == "IT")
            {

                selectProduct.SelectByValue("vel");
                driver.FindElement(By.Id("checkbox-1848"));
            }
            else
            {
                selectProduct.SelectByValue("mot");
                driver.FindElement(By.Id("checkbox-3250"));


            }
        }

        [TearDown]
        public void Fin()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}

