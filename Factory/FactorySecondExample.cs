namespace Factory2
{
    public interface IHuman
    {
        string Action();
    }
    public class HumanFactory
    {
        public void CreateHuman(string capacibilities)
        {
            if (capacibilities.ToLower().Contains("fly"))
            {
                Console.Write("This is a super human ");
                var human = new SuperHuman();
                Console.WriteLine($"and he/she {human.Action()}");
            }
            else
            {
                Console.Write("This is a normal human ");
                var human = new NormalHuman();
                Console.WriteLine($"and he/she {human.Action()}");
            }
        }
    }

    class SuperHuman : IHuman
    {
        public string Action()
        {
            return "Fight crime";
        }
    }

    class NormalHuman : IHuman
    {
        public string Action()
        {
            return "Live normal life";
        }
    }

    public class ExecuteSecondFactory
    {
        public void Main()
        {
            Console.WriteLine("Creating humans:");
            var humanFactory = new HumanFactory();

            humanFactory.CreateHuman("Walk");
            Console.WriteLine("=====================");
            humanFactory.CreateHuman("Walk and Fly");

        }
    }

}