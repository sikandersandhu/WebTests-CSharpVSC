using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace CodeCampTest
{
    public class Menu
    {
        private ChromeDriver driver;

        public Menu(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void ClickFormsPage()
        {
            driver.FindElement(By.CssSelector("[aria-label=forms]")).Click();
        }

        public void ClickPlanetsPage()
        {
            driver.FindElement(By.CssSelector("[aria-label=planets]")).Click();
        }
    }
}