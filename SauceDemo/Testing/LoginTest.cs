using PageObjLib.Factories;
using SauceDemo.Tests;
using SauceDemo.WebPages;

namespace SauceDemo.TestingLogin
{
    public class LoginTest : BaseTest
    {
        [TestCase("https://www.saucedemo.com/inventory.html")]
        public void LoginTestPositive(string expected)
        {
            LoginPage.Login("standard_user", "secret_sauce");

            var result = Driver.GetDriver().Url;

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("Epic sadface: Username is required")]
        public void LoginTestEmptyNegative(string expected)
        {
            LoginPage.Login("", "");

            var result = LoginPage.GetMessage();

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("Epic sadface: Username and password do not match any user in this service")]
        public void LoginTestNegative(string expected)
        {
            LoginPage.Login("453tert", "ertdfghdht");

            var result = LoginPage.GetMessage();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
