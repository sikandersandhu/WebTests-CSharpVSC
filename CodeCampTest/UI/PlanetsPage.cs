using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CodeCampTest
{
    public class PlanetsPage
    {
        private ChromeDriver driver;

        public PlanetsPage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public PlanetTile GetPlanetTile(Predicate<PlanetTile> predicate)
        {
            foreach (IWebElement tile in driver.FindElements(By.ClassName("planet")))
            {
                PlanetTile planet = new PlanetTile(tile);

                if (predicate.Invoke(planet))
                {
                    return planet;
                }
            }
            throw new NotFoundException("Planet not found");
        }
    }
}