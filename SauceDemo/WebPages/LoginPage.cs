using OpenQA.Selenium;
using PageObjLib.Pages;

namespace SauceDemo.WebPages
{
    internal static class LoginPage
    {
        private const string _url = "https://www.saucedemo.com";
        public readonly static string _password = "secret_sauce";
        public readonly static Dictionary<string, string> LoginCredentials = new()
        {
            {"standard", "standard_user"},
            {"locked", "locked_out_user"},
            {"problem", "problem_user"},
            {"performance", "performance_glitch_user"},
            {"error", "error_user"},
            {"visual", "visual_user"}
        };

        private static IWebElement UserNameInput() => Page.GetElement(By.Id("user-name"));
        private static IWebElement PasswordInput() => Page.GetElement(By.Name("password"));
        private static IWebElement LoginButton() => Page.GetElement(By.XPath("//input[@id='login-button']"));
        private static IWebElement ErrorMessage() => Page.GetElement(By.CssSelector("h3[data-test='error']"));

        public static void Login(string login, string password)
        {
            UserNameInput().SendKeys(login);
            PasswordInput().SendKeys(password);
            LoginButton().Click();
        }

        public static string GetMessage() => ErrorMessage().Text;
    }
}
