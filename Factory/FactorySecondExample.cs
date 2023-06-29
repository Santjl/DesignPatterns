namespace Factory2
{
    public interface IPage
    {
        public bool OnlyAdmin { get;}
        string Page();
    }
    public class AppFactory
    {
        public void BuildApp(string role)
        {
            var pages = new List<IPage>
            {
                new AdministratorPage(),
                new ConfigureAppPage(),
                new LoginPage(),
                new ProfilePage()
            };

            var isAdmin = role.ToLower() == "admin";
            pages = pages.Where(x => x.OnlyAdmin == isAdmin).ToList();

            Console.WriteLine("Pages:");
            pages.ForEach(x =>
            {
                Console.WriteLine($"- {x.Page()}");
            });
        }
    }

    class AdministratorPage : IPage
    {
        public bool OnlyAdmin { get; } = true;
        public string Page()
        {
            return "AdministratorPainelPage";
        }
    }

    class ConfigureAppPage : IPage
    {
        public bool OnlyAdmin { get; } = true;
        public string Page()
        {
            return "ConfigureAppPage";
        }
    }
    class LoginPage : IPage
    {
        public bool OnlyAdmin { get; } = false;
        public string Page()
        {
            return "NormalPage";
        }
    }
    class ProfilePage : IPage
    {
        public bool OnlyAdmin { get; } = false;
        public string Page()
        {
            return "ProfilePage";
        }
    }

    public class ExecuteAppFactory
    {
        public void Main()
        {
            Console.WriteLine("Please write your role:");
            Console.WriteLine();
            var role = Console.ReadLine();
            var app = new AppFactory();
            app.BuildApp(role!);
        }
    }

}