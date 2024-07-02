using OpenQA.Selenium;
using PageObjLib.Factories;
using PageObjLib.Pages;

namespace SauceDemo.WebPages
{
    internal static class BurgerMenu
    {
        public static IWebElement BurgerMenuButton() => Page.GetElement(By.Id("react-burger-menu-btn"));
        public static IWebElement LogoutButton() => Page.GetElement(By.Id("logout_sidebar_link"));
    }
}
