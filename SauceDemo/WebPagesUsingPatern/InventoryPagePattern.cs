
using OpenQA.Selenium;
using PageObjLib.Factories;
using PageObjLib.Pages;
using SauceDemo.WebPages;
using SeleniumExtras.PageObjects;

namespace SauceDemo.WebPagesUsingPatern
{
    internal class InventoryPagePattern : BasePage
    {   
        [FindsBy(How = How.CssSelector, Using = "[name|='add-to-cart']))")]
        private IWebElement AddToCartButton;

        [FindsBy(How = How.ClassName, Using = "product_sort_container")]
        private IWebElement SortButton;

        [FindsBy(How = How.XPath, Using = "//*[@value='za']")]
        private IWebElement ZASort;

        [FindsBy(How = How.XPath, Using = "//*[@value='lohi']")]
        private IWebElement LoHiSort;

        private static List<IWebElement> ListOfPrices() => Driver.GetDriver().FindElements(By.CssSelector("div[class$='_item_price']")).ToList();
        private static List<IWebElement> ListOfItemNamesUnSort;
        private static List<IWebElement> ListOfItemNamesSort;

        public InventoryPagePattern()
        {
            PageFactory.InitElements(Driver.GetDriver(), this);
        }

        public override InventoryPagePattern IsPageOpened()
        {
            Page.GetElement(By.ClassName("product_sort_container"));
            return this;
        }

        public override InventoryPagePattern OpenUrl()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://www.saucedemo.com");
            return this;
        }

        public InventoryPagePattern GetUnsortableList()
        {
            ListOfItemNamesUnSort = Page.GetListOfElements(By.XPath("//div[@class='inventory_item_name ' and @data-test='inventory-item-name']")).ToList();
            return this;
        }

        public InventoryPagePattern GetSortList()
        {
            ListOfItemNamesSort = Page.GetListOfElements(By.XPath("//div[@class='inventory_item_name ' and @data-test='inventory-item-name']")).ToList();
            return this;
        }
        public InventoryPagePattern SortButtonClik()
        {
            SortButton.Click();
            return this;
        }

        public InventoryPagePattern ZaButtonClick()
        {
            ZASort.Click();
            return this;
        }

        public static bool IsSortableZA()
        {
            var elementsOrderByDescending = ListOfItemNamesUnSort.Select(e => e.Text).OrderByDescending(e => e).ToList();

            return elementsOrderByDescending.Select(e => e).ToString() == ListOfItemNamesSort.Select(s => s).ToString();
        }
    }
}
