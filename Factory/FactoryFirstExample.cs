namespace Factory
{
    public interface IHuman
    {
        string HumanCapacibilities();
    }
    abstract class HumanFactory
    {
        public abstract IHuman CreateHuman();

        public string HumanCapacibilities()
        {
            var human = CreateHuman();
            return $"This human have this capacibilities: {human.HumanCapacibilities()}";
        }
    }

    class SuperHuman : HumanFactory
    {
        public override IHuman CreateHuman()
        {
            return new Human("Fly");
        }
    }

    class NormalHuman : HumanFactory
    {
        public override IHuman CreateHuman()
        {
            return new Human("Walk");
        }
    }

    class Human : IHuman
    {
        public string Capacibilities { get; set; }

        public Human(string capacibilities)
        {
            Capacibilities = capacibilities;
        }

        public string HumanCapacibilities() 
        {
            return Capacibilities;
        }
    }

    public class ExecuteFirstFactory
    {
        public void Main()
        {
            Console.WriteLine("Creating Normal Human: ");
            ReturnHumanCapacibilities(new NormalHuman());
            Console.WriteLine("=====================");
            Console.WriteLine("Creating Super Human: ");
            ReturnHumanCapacibilities(new SuperHuman());

        }

        private void ReturnHumanCapacibilities(HumanFactory factory)
        {
            Console.WriteLine(factory.HumanCapacibilities());
        }
    }

}