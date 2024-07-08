
using SauceDemo.Models.Users;
using SauceDemo.WebPagesUsingPatern;

namespace SauceDemo.TestingWithPatterns
{
    internal class SortTestPatern : BaseTestPatern
    {
        [Test, TestCaseSource(nameof(UserTestCases))]
        public void SortAZTest(BaseUser user, bool expected)
        {
            LoginPagePattern loginPage = new();
            InventoryPagePattern inventoryPage = new();

            loginPage
                .OpenUrl()
                .SendName(user)
                .SendPAss(user)
                .LogInButtonClick();

            inventoryPage
                .GetUnsortableList()
                .SortButtonClik()
                .ZaButtonClick()
                .GetSortList();

            Assert.That(InventoryPagePattern.IsSortableZA(), Is.EqualTo(expected));
        }

        public static IEnumerable<TestCaseData> UserTestCases
        {
            get
            {
                yield return new TestCaseData(new StandartUser(), true);
                yield return new TestCaseData(new ProblemUser(), true);
                yield return new TestCaseData(new GlitchUser(), true);
                yield return new TestCaseData(new LocedOutUser(), true);
            }
        }
    }
}
