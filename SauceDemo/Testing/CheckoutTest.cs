using SauceDemo.Tests;
using SauceDemo.WebPages;

namespace SauceDemo.TestingCheckout
{
    internal class CheckoutTest : BaseTest
    {
        [TestCase("Thank you for your order!")]
        public void CheckoutTest1(string expected)
        {
            LoginPage.Login("standard_user", "secret_sauce");

            var d = InventoryPage.AddToCardButtons();
            InventoryPage.AddItemToCart(0);
            InventoryPage.AddItemToCart(0);
            InventoryPage.AddItemToCart(0);

            CartPage.CartButton().Click();

            CartPage.ChekcoutButton().Click();

            CartPage.FirstNameInput("User");
            CartPage.LastNameInput("Test");
            CartPage.ZipCodeInput("123456");

            CartPage.ContinueButton().Click();

            CartPage.FinishButton().Click();

            var result = CartPage.FinishMessage().Text;

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
