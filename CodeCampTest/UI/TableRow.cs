using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampTest.UI
{
    public class TableRow
    {
        private IWebElement rowElement;

        public TableRow(IWebElement elem)
        {
            this.rowElement = elem;
        }

        public string Item
        {
            get
            {
                var cells = rowElement.FindElements(By.TagName("td"));
                foreach (IWebElement cell in cells)
                {
                    if (cell.GetAttribute("cellIndex").Equals(1))
                    {
                        return cell.Text;
                    }
                }
                return "";
            }
        }

        public string Price
        {
            get
            {
                var cells = rowElement.FindElements(By.TagName("td"));
                foreach (IWebElement cell in cells)
                {
                    if (cell.GetAttribute("cellIndex").Equals(2))
                    {
                        return cell.Text;
                    }
                }
                return "";
            }
        }

        public string SubTotal
        {
            get
            {
                var cells = rowElement.FindElements(By.TagName("td"));
                foreach (IWebElement cell in cells)
                {
                    if (cell.GetAttribute("cellIndex").Equals(3))
                    {
                        return cell.Text;
                    }
                }
                return "";
            }
        }

        public string Qty
        {
            get
            {
                var cells = rowElement.FindElements(By.TagName("td"));
                foreach (IWebElement cell in cells)
                {
                    if (cell.GetAttribute("cellIndex").Equals(0))
                    {
                        return cell.Text;
                    }
                }
                return "";
            }
        }

    }
}
