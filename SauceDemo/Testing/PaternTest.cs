using PageObjLib.Factories;
using SauceDemo.Models;
using SauceDemo.Tests;
using SauceDemo.WebPages;

namespace SauceDemo.Testing
{
    internal class PaternTest : BaseTest
    {
       

        [TestCase("Products", "standard_user", "secret_sauce")]
        public void LoginTestPositive(string expected, string name, string pass)
        {
            User user = new(name, pass);

            LoginPagePattern loginPage = new();

            loginPage
                .OpenUrl()
                .SendName(user.Name)
                .SendPAss(user.Pass)
                .LogInButtonClick();
           
            Assert.That(loginPage.GetProductTetx(), Is.EqualTo(expected));
        }

    }
}
