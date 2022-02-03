using CodeCampTest.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace CodeCampTest
{
    [TestClass]
    public class WebTests
    {
        private ChromeDriver driver;
        
        [TestInitialize]
        public void SetUp()
        {
            // ARRANGE

            // set web driver
            driver = new ChromeDriver();
            // set the url for the driver
            driver.Url = ("https://d18u5zoaatmpxx.cloudfront.net/#/");
            // maximize window
            driver.Manage().Window.FullScreen();
        }
        
        [TestMethod]
        public void ClickClickMeDown()
        {
            // ACT

            // find "click me down! element 
            IWebElement clickMeDownBtn = driver.FindElement(By.CssSelector("[role='button']"));
            // click on it 
            clickMeDownBtn.Click();

            
            // WAIT

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => clickMeDownBtn.Text != "CLICK ME DOWN!");


            // ASSERT
            
            // assert that the message displays "click me up!"
            Assert.AreEqual("CLICK ME UP!", clickMeDownBtn.Text);
 
        }

        [TestMethod]
        public void FindItemPrice()
        {
            // ACT

            // find table rows, assign to list
            var tableRow = new List<IWebElement>(driver.FindElements(By.TagName("tr")));

            // look for matching attribute in row | Levi 501s classic denim @ cellIndex: 1
            foreach (IWebElement row in tableRow)
            {

                // create a row object
                TableRow rowObj = new TableRow(row);

               // if the row object contains desired text, then print the price for that item
                if (rowObj.Item.Contains("Levi 501s")) {

                    // ASSERT

                    // assert name 
                    Assert.AreEqual("Levi 501s classic denim", rowObj.Item);
                    // assert price
                    Assert.AreEqual("$69.99", rowObj.Price);

                }
                
            }
        }

        [TestMethod]
        public void CheckDistanceToJupiter()
        {
            // ARRANGE

            // set menu
            var menu = new Menu(driver);
            // open planets page
            menu.ClickPlanetsPage();


            // ACT

            var planetsPage = new PlanetsPage(driver);

            PlanetTile planet = planetsPage.GetPlanetTile(p => p.Name.ToLower() == "jupiter");

            //ASSERT

            // assert distance to jupiter
            Assert.AreEqual("778,500,000 km", planet.Distance);

        }

        [TestMethod]
        public void CheckRadiusOfMars()
        {
            // ARRANGE

            // create menu bar object
            var menu = new Menu(driver);
            // open planets page
            menu.ClickPlanetsPage();


            // ACT
            
            // create planets page object
            var planetsPage = new PlanetsPage(driver);
            
            // find the planet tile in the list that matches the radius
            PlanetTile planet = planetsPage.GetPlanetTile(p => p.DoubleRadius == 3389.5);

            //ASSERT

            // assert mars's radius 
            Assert.AreEqual("mars", planet.Name.ToLower());

        }

        // find AUT home button                                        |  css  | aria-label="home"
        // click on home button to go to page
        // Go to States and Transitions block                           
        // find the input element corresponding to Forename element    | ById   | id="forename"
        // enter name
        // find submit element                                         | ById   | id="submit"
        // press submit
        // put a wait
        // check that [hello + "name"] message is displayed            | ByCss  | class="snackbar popup-message mr-auto"

        [TestMethod]
        public void SubmitStatesAndTransitionsForm()
        {
            // arrange

            // initialize menu object
            Menu menu = new Menu(driver);
            // go to "HOME" page
            menu.clickHomePage();


            // act

            // initialize statesAndTransitionsBlock object to get elements 
            StatesAndTransitionsBlock statesAndTransitionsBlock = new StatesAndTransitionsBlock(driver);
            // enter forename
            statesAndTransitionsBlock.Forename = "Sikander";
            // submit form
            statesAndTransitionsBlock.SubmitForm();

            // wait
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => statesAndTransitionsBlock.PopUpMessage == "Hello Sikander");

            //assert
            Assert.AreEqual("Hello Sikander", statesAndTransitionsBlock.PopUpMessage);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
