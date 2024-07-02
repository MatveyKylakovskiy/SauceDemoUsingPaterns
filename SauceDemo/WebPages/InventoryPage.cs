using OpenQA.Selenium;
using PageObjLib.Factories;

namespace SauceDemo.WebPages
{
    internal static class InventoryPage
    {
        public static List<IWebElement> AddToCardButtons() => Driver.GetDriver().FindElements(By.CssSelector("[name|='add-to-cart']")).ToList();
        private static List<IWebElement> ListOfPrices() => Driver.GetDriver().FindElements(By.CssSelector("div[class$='_item_price']")).ToList();
        private static List<IWebElement> ListOfItemNames() => Driver.GetDriver().FindElements(By.XPath("//div[@class='inventory_item_name ' and @data-test='inventory-item-name']")).ToList();
        private static IWebElement SortButton() => Driver.GetDriver().FindElement(By.ClassName("product_sort_container"));
        private static IWebElement ZASort() => Driver.GetDriver().FindElement(By.XPath("//*[@value='za']"));
        private static IWebElement LoHiSort() => Driver.GetDriver().FindElement(By.XPath("//*[@value='lohi']"));

        public static bool IsSortableZA()
        {
            var elementsOrderByDescending = ListOfItemNames().Select(e => e.Text).OrderByDescending(e => e).ToList();
            SortButton().Click();
            ZASort().Click();

            var sortZA = ListOfItemNames().Select(s => s.Text).ToList();

            return elementsOrderByDescending.Select(e => e).ToString() == sortZA.Select(s => s).ToString();
        }

        public static bool IsSortableLoHi()
        {
            var elementsOrder = ListOfPrices().Select(e => e.Text).Select(e => e.Remove(0, 1)).Select(e => e.Replace(".", ",")).Select(e => double.Parse(e)).OrderBy(e => e).ToList();
            SortButton().Click();
            LoHiSort().Click();

            var sortLoHi = ListOfPrices().Select(s => s.Text).Select(e => e.Remove(0, 1)).Select(e => e.Replace(".", ",")).Select(e => double.Parse(e)).ToList();

            return elementsOrder.Select(e => e).ToString() == sortLoHi.Select(s => s).ToString();
        }

        public static void AddItemToCart(int number) => AddToCardButtons()[number].Click();
    }
}