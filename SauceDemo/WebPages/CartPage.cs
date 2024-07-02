using OpenQA.Selenium;
using PageObjLib.Pages;

namespace SauceDemo.WebPages
{
    internal static class CartPage
    {
        public static IWebElement CartButton() => Page.GetElement(By.ClassName("shopping_cart_link"));
        public static List<IWebElement> ListOfItems() => Page.GetListOfElements(By.XPath("//div[@class='cart_item']"));
        public static IWebElement ChekcoutButton() => Page.GetElement(By.Id("checkout"));
        public static IWebElement ContinueButton() => Page.GetElement(By.Id("continue"));
        public static IWebElement FinishButton() => Page.GetElement(By.XPath("//*[@name='finish']"));
        public static IWebElement FinishMessage() => Page.GetElement(By.XPath("//*[text()='Thank you for your order!']"));
        public static void FirstNameInput(string firstName) => Page.GetElement(By.Id("first-name")).SendKeys(firstName);
        public static void LastNameInput(string lastName) => Page.GetElement(By.Id("last-name")).SendKeys(lastName);
        public static void ZipCodeInput(string zipCode) => Page.GetElement(By.Id("postal-code")).SendKeys(zipCode);
    }
}
