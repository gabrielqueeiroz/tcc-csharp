using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace NUnitTest
{
    public class Tests
    {
        Dictionary<string, string> person = new Data().generateData();
        string URL = "https://www.grocerycrud.com/v1.x/demo/my_boss_is_in_a_hurry/bootstrap";
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void beforeClass()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void RegisterUser()
        {
            driver.Url = URL;
            driver.Manage().Window.Maximize();
            var homePage = new HomePage(driver);
            var formPage = new FormPage(driver);
            PageFactory.InitElements(driver, homePage);
            PageFactory.InitElements(driver, formPage);

            homePage.AddCustomer();
            formPage.FillForm01(person);
        }

        [Test]
        public void DeleteUser()
        {
            driver.Url = URL;
            driver.Manage().Window.Maximize();
            var homePage = new HomePage(driver);
            var formPage = new FormPage(driver);
            PageFactory.InitElements(driver, homePage);
            PageFactory.InitElements(driver, formPage);

            homePage.AddCustomer();
            formPage.FillForm02(person);
            homePage.DeleteCustomer(person["name"]);
        }

        [Test]
        public void CheckColumns()
        {
            driver.Url = URL;
            driver.Manage().Window.Maximize();
            var homePage = new HomePage(driver);
            var formPage = new FormPage(driver);
            PageFactory.InitElements(driver, homePage);
            PageFactory.InitElements(driver, formPage);

            homePage.VerifyColumns();
        }
    }
}