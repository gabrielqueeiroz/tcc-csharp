using System;
using OpenQA.Selenium;
using NUnit.Framework;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;


namespace NUnitTest
{
    internal class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/select/option[4]")]
        [CacheLookup]
        private IWebElement Combo_select { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[1]/div[2]/form/div[1]/div[1]/a")]
        [CacheLookup]
        private IWebElement Add_customer_button { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[1]/div[2]/form/div[2]/table/thead/tr[2]/td[3]/input")]
        [CacheLookup]
        private IWebElement Search_name { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"gcrud-search-form\"]/div[2]/table/thead/tr[2]/td[1]/div/input")]
        [CacheLookup]
        private IWebElement Actions_checkbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"gcrud-search-form\"]/div[2]/table/thead/tr[2]/td[2]/div[1]/a")]
        [CacheLookup]
        private IWebElement Delete_button { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[3]/div/div/div[2]")]
        [CacheLookup]
        private IWebElement Delete_message { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[3]/div/div/div[3]/button[2]")]
        [CacheLookup]
        private IWebElement Delete_popup_button { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/span[3]/p")]
        [CacheLookup]
        public IWebElement Popup_message { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[1]/div[2]/form/div[2]/table/thead/tr[2]/td[2]/div[2]/a")]
        [CacheLookup]
        private IWebElement Update_button { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"gcrud-search-form\"]/div[2]/table/thead/tr[1]/th[1]")]
        [CacheLookup]
        private IWebElement Column_1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"gcrud-search-form\"]/div[2]/table/thead/tr[1]/th[2]")]
        [CacheLookup]
        private IWebElement Column_2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"gcrud-search-form\"]/div[2]/table/thead/tr[1]/th[3]")]
        [CacheLookup]
        private IWebElement Column_3 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"gcrud-search-form\"]/div[2]/table/thead/tr[1]/th[4]")]
        [CacheLookup]
        private IWebElement Column_4 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"gcrud-search-form\"]/div[2]/table/thead/tr[1]/th[5]")]
        [CacheLookup]
        private IWebElement Column_5 { get; set; }

        public void AddCustomer()
        {
            Combo_select.Click();
            Add_customer_button.Click();
        }

        public void DeleteCustomer(string name)
        {
            Console.WriteLine(name);
            Search_name.SendKeys(name);
            Update_button.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]")));
            Actions_checkbox.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"gcrud-search-form\"]/div[2]/table/thead/tr[2]/td[2]/div[1]/a")));
            Delete_button.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[2]/div[3]/div/div/div[3]/button[1]")));
            Assert.AreEqual(Delete_message.Text, "Are you sure that you want to delete this 1 item?");
            Delete_popup_button.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[4]/span[3]/p")));
            Assert.AreEqual(Popup_message.Text, "Your data has been successfully deleted from the database.");
        }

        public void VerifyColumns()
        {
            Assert.AreEqual(Column_1.Text, "Actions");
            Assert.AreEqual(Column_2.Text, "CustomerName");
            Assert.AreEqual(Column_3.Text, "Phone");
            Assert.AreEqual(Column_4.Text, "AddressLine1");
            Assert.AreEqual(Column_5.Text, "CreditLimit");

        }
    }
}
