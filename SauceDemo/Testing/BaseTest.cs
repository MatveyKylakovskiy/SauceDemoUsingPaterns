using PageObjLib.Factories;
using PageObjLib.Pages;
using SauceDemo.WebPages;

namespace SauceDemo.Tests
{
    public class BaseTest
    {
        [SetUp]
        public void SetUp() => BasePage.OpenPage();

        [TearDown]
        public void TearDown()
        {
            Driver.QuitDriver();
            Driver.QuitWait();
            Page.QuitActions();
        }
    }
}
