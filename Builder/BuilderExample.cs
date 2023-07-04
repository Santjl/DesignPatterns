using System.Runtime.CompilerServices;

namespace Builder
{
    public interface IProductBuilder
    {
        void BuildProduct(string name, string description, double price);
        void WithDistributionCenter(string distributionCenter);
        void WithFactory(string factory);
        void WithShop(string shop);
    }
    public class ProductBuilder : IProductBuilder
    {
        private Product _product = new Product();

        public ProductBuilder()
        {
            Reset();
        }

        public void BuildProduct(string name, string description, double price)
        {
            _product = new Product
            {
                Name = name,
                Description = description,
                Price = price
            };
        }
        public void WithDistributionCenter(string distributionCenter)
        {
            _product.DistributionCenter = distributionCenter;
        }

        public void WithFactory(string factory)
        {
            _product.Factory = factory;
        }

        public void WithShop(string shop)
        {
            _product.Shop = shop;
        }

        public void Reset()
        {
            _product = new Product();
        }

        public Product GetProduct()
        {
            Product result = this._product;

            if (result is null)
                throw new NullReferenceException("Product is cannot be null");

            Reset();

            return result;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string DistributionCenter { get; set; }
        public string Factory { get; set; }
        public string Shop { get; set; }

        public string DescribleProduct()
        {
            var hasDistributionCenter = this.DistributionCenter is not null;
            var hasFactoriy = this.Factory is not null;
            var hasShop = this.Shop is not null;

            var description = $"Name: {Name} \n" +
                $"Description: {Description} \n" +
                $"Price: {Price} \n";

            if (hasFactoriy)
                description = string.Concat(description, $"Manufactured by {Factory}\n");

            if(hasDistributionCenter)
                description = string.Concat(description, $"Distributed by {DistributionCenter}\n");

            description = string.Concat(description, hasShop ? $"Available for purchase on {Shop}" : $"Inavailable for purchase");

            return description;
        }
    }

    public class Director
    {
        private IProductBuilder _builder = null!;

        public IProductBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildMinimalProduct()
        {
            this._builder.BuildProduct("Sample Product Name 01", "Sample Product Description", 100.0);
        }

        public void BuildMinimalWithFactory()
        {
            this._builder.BuildProduct("Sample Product Name 02", "Sample Product Description", 100.0);
            this._builder.WithFactory("Light Factory");
        }

        public void BuildFullProduct()
        {
            this._builder.BuildProduct("Sample Product Name 03", "Sample Product Description", 100.0);
            this._builder.WithFactory("Light Shopping");
            this._builder.WithDistributionCenter("LCD02");
            this._builder.WithShop("Light Shopping");
        }
    }

    public class ExecuteBuilder
    {
        public void Main()
        {
            var director = new Director();
            var productBuilder = new ProductBuilder();
            director.Builder = productBuilder;

            Console.WriteLine("Sample Product");
            director.BuildMinimalProduct();
            Console.WriteLine(productBuilder.GetProduct().DescribleProduct());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Product with Factory");
            director.BuildMinimalWithFactory();
            Console.WriteLine(productBuilder.GetProduct().DescribleProduct());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Product with all properties");
            director.BuildFullProduct();
            Console.WriteLine(productBuilder.GetProduct().DescribleProduct());
        }
    }
}