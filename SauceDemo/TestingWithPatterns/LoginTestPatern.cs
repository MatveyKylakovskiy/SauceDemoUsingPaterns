using PageObjLib.Factories;
using SauceDemo.Models.Users;
using SauceDemo.Tests;
using SauceDemo.WebPagesUsingPatern;

namespace SauceDemo.TestingWithPatterns
{
    internal class LoginTestPatern : BaseTestPatern
    {
        [Test, TestCaseSource(nameof(UserTestCases))]
        public void LoginTest(BaseUser user, string expected)
        {
            LoginPagePattern loginPage = new();

            loginPage
                .OpenUrl()
                .SendName(user)
                .SendPAss(user)
                .LogInButtonClick();

            Assert.That(loginPage.GetProductTetx(), Is.EqualTo(expected));
        }

        public static IEnumerable<TestCaseData> UserTestCases
        {
            get
            {
                yield return new TestCaseData(new StandartUser(), "Products");
                yield return new TestCaseData(new ProblemUser(), "Products");
                yield return new TestCaseData(new GlitchUser(), "Products");
            }
        }
    }
}
