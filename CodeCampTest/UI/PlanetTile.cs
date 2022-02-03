using OpenQA.Selenium;
using System;

namespace CodeCampTest
{
    public class PlanetTile
    {
        private IWebElement tile;

        public PlanetTile(IWebElement tile)
        {
            this.tile = tile;
        }

        public string Name => tile.FindElement(By.ClassName("name")).Text;
        public string Distance => tile.FindElement(By.ClassName("distance")).Text;
        public string Radius => tile.FindElement(By.ClassName("radius")).Text;
        public double DoubleDistance
        {
            get
            {
                string unformatted = tile.FindElement(By.ClassName("distance")).Text;
                string formatted = unformatted.Replace(" km", "").Replace(",", "");
                return Convert.ToDouble(formatted);
            }
        }
        public double DoubleRadius
        {
            get
            {
                string unformatted = tile.FindElement(By.ClassName("radius")).Text;
                string formatted = unformatted.Replace(" km", "").Replace(",", "");
                return Convert.ToDouble(formatted);
            }
        }

    }
}