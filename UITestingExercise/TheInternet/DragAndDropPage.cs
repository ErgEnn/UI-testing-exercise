
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TheInternet
{
    public class DragAndDropPage : BaseWebDriverUser
    {

        private readonly By _column = By.ClassName("column");
        private readonly By _columnA = By.Id("column-a");
        private readonly By _columnB = By.Id("column-b");
        private readonly By _columnAXPath = By.XPath("/html/body/div[2]/div/div/div/div[1]");
        private readonly By _columnBXPath = By.XPath("/html/body/div[2]/div/div/div/div[2]");

        public DragAndDropPage(IWebDriver driver) : base(driver)
        {
        }

        public IReadOnlyCollection<IWebElement> Columns() => Driver.FindElements(_column);

        public List<string> Elements() => Columns().Select(element => element.Text).ToList();

        public IWebElement ColumnA() => Driver.FindElement(_columnA);

        public IWebElement ColumnB() => Driver.FindElement(_columnB);

        public void DragFromColAToColB()
        {
            Actions builder = new Actions(Driver);

            builder.ClickAndHold(ColumnA()).MoveByOffset(150,0).Release().Build().Perform();
        }

    }
}
