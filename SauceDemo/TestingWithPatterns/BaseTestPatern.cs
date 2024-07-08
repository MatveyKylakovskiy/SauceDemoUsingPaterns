using PageObjLib.Factories;
using PageObjLib.Pages;

namespace SauceDemo.TestingWithPatterns
{
    internal class BaseTestPatern
    {
        [TearDown]
        public void TearDown()
        {
            Driver.QuitDriver();
            Driver.QuitWait();
            Page.QuitActions();
        }
    }
}
