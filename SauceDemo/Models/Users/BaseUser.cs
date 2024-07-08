namespace SauceDemo.Models.Users
{
    internal abstract class BaseUser
    {
        public string Name;
        public string Pass = "secret_sauce";

        public BaseUser(string name, string pass)
        {
            Name = name;
            Pass = pass;
        }

        public BaseUser()
        {

        }
    }
}
