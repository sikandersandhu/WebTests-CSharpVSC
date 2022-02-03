using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CodeCampTest
{

    public class StatesAndTransitionsBlock
    {
        private ChromeDriver driver;

        public StatesAndTransitionsBlock(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public string Forename
        {
            get { return driver.FindElement(By.Id("forename")).Text; }
            set
            {
                IWebElement forename = driver.FindElement(By.Id("forename"));
                forename.Clear();
                forename.SendKeys(value);
            }
        }

        public void SubmitForm() { driver.FindElement(By.Id("submit")).Click(); }

        public string PopUpMessage => driver.FindElement(By.CssSelector("[class='snackbar popup-message mr-auto']")).Text;
    }
}