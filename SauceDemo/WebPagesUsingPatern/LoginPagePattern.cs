using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using PageObjLib.Factories;
using PageObjLib.Pages;
using SauceDemo.WebPages;
using SauceDemo.Models.Users;

namespace SauceDemo.WebPagesUsingPatern
{
    internal class LoginPagePattern : BasePage
    {
        private BaseUser user;

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement UserNameField;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//input[@id='login-button']")]
        private IWebElement LoginButton;


        public LoginPagePattern()
        {
            PageFactory.InitElements(Driver.GetDriver(), this);
        }

        public LoginPagePattern SendName(BaseUser user)
        {
            UserNameField.SendKeys(user.Name);
            return this;
        }

        public LoginPagePattern SendPAss(BaseUser user)
        {
            PasswordField.SendKeys(user.Pass);
            return this;
        }

        public LoginPagePattern LogInButtonClick()
        {
            LoginButton.Click();
            return this;
        }

        public override LoginPagePattern IsPageOpened()
        {
            Page.GetElement(By.ClassName("product_sort_container"));
            return this;
        }

        public override LoginPagePattern OpenUrl()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://www.saucedemo.com");
            return this;
        }

        public string GetProductTetx() => Page.GetElement(By.XPath("//*[@class='title']")).Text;

        public static void LoginByUser(BaseUser user)
        {
            LoginPagePattern loginPage = new();

            loginPage
                .OpenUrl()
                .SendName(user)
                .SendPAss(user)
                .LogInButtonClick();
        }
    }
}
