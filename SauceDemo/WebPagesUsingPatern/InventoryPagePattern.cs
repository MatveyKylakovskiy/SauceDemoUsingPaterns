
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

        [FindsBy(How = How.XPath, Using = "//*[@class='product_sort_container']")]
        private IWebElement SortButton;

        [FindsBy(How = How.XPath, Using = "//*[@value='za']")]
        private IWebElement ZASort;

        [FindsBy(How = How.XPath, Using = "//*[@value='lohi']")]
        private IWebElement LoHiSort;

        private static List<IWebElement> ListOfPricesUnSort; 
        private static List<IWebElement> ListOfPricesSort; 
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
        public InventoryPagePattern GetSortListOfPriceUnSort()
        {
            ListOfPricesUnSort = Page.GetListOfElements(By.CssSelector("div[class$='_item_price']")).ToList();
            return this;
        }
        public InventoryPagePattern GetSortListOfPriceSort()
        {
            ListOfPricesSort = Page.GetListOfElements(By.CssSelector("div[class$='_item_price']")).ToList();
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

        public InventoryPagePattern LoHiButtonClick()
        {
            LoHiSort.Click();
            return this;
        }

        public static bool IsSortableZA()
        {
            var elementsOrderByDescending = ListOfItemNamesUnSort.Select(e => e.Text).OrderByDescending(e => e).ToList();
            var listOfItems = ListOfItemNamesSort.Select(s => s.Text).ToList();

            return elementsOrderByDescending.Select(e => e).ToString() == listOfItems.Select(s => s).ToString();
        }

        public static bool IsSortableLoHi()
        {
            var elementsOrder = ListOfPricesUnSort.Select(e => e.Text).Select(e => e.Remove(0, 1)).Select(e => e.Replace(".", ",")).Select(e => double.Parse(e)).OrderBy(e => e).ToList();
            var sortLoHi = ListOfPricesSort.Select(s => s.Text).Select(e => e.Remove(0, 1)).Select(e => e.Replace(".", ",")).Select(e => double.Parse(e)).ToList();

            return elementsOrder.Select(e => e).ToString() == sortLoHi.Select(s => s).ToString();
        }
    }
}
