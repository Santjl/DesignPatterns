namespace Factory
{
    public interface IPage
    {
        string PageName();
    }
    abstract class PageFactory
    {
        public abstract IPage GeneratePage(string role);

        public string ViewPage(string role)
        {
            var page = GeneratePage(role);
            return $"Open {page.PageName()} page like {role}";
        }
    }

    class FeedPage : PageFactory
    {
        public override IPage GeneratePage(string role)
        {
            return new Page("Feed");
        }
    }

    class ProfilePage : PageFactory
    {
        public override IPage GeneratePage(string role)
        {
            return new Page("Profile");
        }
    }

    class Page : IPage
    {
        public string Name { get; set; }

        public Page(string pageName)
        {
            Name = pageName;
        }

        string IPage.PageName()
        {
            return Name;
        }
    }

    public class ExecutePageVisionFactory
    {
        public void Main()
        {
            Console.WriteLine("Please write your role:");
            var role = Console.ReadLine();
            ReturnPage(new ProfilePage(), role!);
            ReturnPage(new FeedPage(), role!);
        }

        private void ReturnPage(PageFactory factory, string role)
        {
            Console.WriteLine(factory.ViewPage(role));
        }
    }

}