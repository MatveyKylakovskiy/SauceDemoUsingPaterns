using PageObjLib.Factories;
using SauceDemo.Tests;
using SauceDemo.WebPages;

namespace SauceDemo.TestingBurger
{
    internal class BurgerMenuTest : BaseTest
    {
        [TestCase("https://www.saucedemo.com/inventory.html", "https://www.saucedemo.com/")]
        public void BurgerMenuLogoutTest(string expected1, string exprcted2)
        {
            LoginPage.Login("standard_user", "secret_sauce");

            var result1 = Driver.GetDriver().Url == expected1;

            BurgerMenu.BurgerMenuButton().Click();
            BurgerMenu.LogoutButton().Click();

            var d = Driver.GetDriver().Url;
            var result2 = Driver.GetDriver().Url == exprcted2;

            Assert.IsTrue(result1 == result2);
        }
    }
}
