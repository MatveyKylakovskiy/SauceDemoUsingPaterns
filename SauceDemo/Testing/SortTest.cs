using SauceDemo.Tests;
using SauceDemo.WebPages;

namespace SauceDemo.TestingSort
{
    internal class SortTest : BaseTest
    {
        [Test]
        public void SortTestZA()
        {
            LoginPage.Login("standard_user", LoginPage._password);

            Assert.IsTrue(InventoryPage.IsSortableZA());
        }

        [Test]
        public void SortTestLoHi()
        {
            LoginPage.Login("standard_user", LoginPage._password);

            Assert.IsTrue(InventoryPage.IsSortableZA());
        }
    }
}
