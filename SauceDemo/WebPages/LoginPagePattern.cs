using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using PageObjLib.Factories;
using PageObjLib.Pages;

namespace SauceDemo.WebPages
{
    internal class LoginPagePattern : BasePage
    {

        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement UserNameField;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//input[@id='login-button']")]
        public IWebElement LoginButton;

        
        public LoginPagePattern()
        {
            PageFactory.InitElements(Driver.GetDriver(), this);
        }

        public LoginPagePattern SendName(string name)
        {
            UserNameField.SendKeys(name);
            return this;
        }

        public LoginPagePattern SendPAss(string name)
        {
            PasswordField.SendKeys(name);
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
    }
}
