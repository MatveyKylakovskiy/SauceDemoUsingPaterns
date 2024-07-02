using PageObjLib.Pages;

namespace SauceDemo.WebPages
{
    internal abstract class BasePage
    {
        private const string _url = "https://www.saucedemo.com";
        public static void OpenPage() => Page.GoUrl(_url);

        public abstract BasePage IsPageOpened();
        public abstract BasePage OpenUrl();

        public BasePage()
        {

        }
    }
}