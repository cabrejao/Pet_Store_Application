using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Store_Application
{
    public class ProductLogic: IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashVariable;
        private Dictionary<string, CatFood> _catFoodVariable;
        public ProductLogic()
        {
            _products = InitProducts();
            _catFoodVariable = new Dictionary<string, CatFood>();
            _dogLeashVariable = new Dictionary<string, DogLeash>();
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
            //step 11 github, step 3 3 "adding a dictionary" docx
            if (product is DogLeash)
            {
                _dogLeashVariable.Add(product.Name, product as DogLeash);
            }
            else if (product is CatFood)
            {
                _catFoodVariable.Add(product.Name, product as CatFood);
            }

        }
        public List<Product> GetAllProducts()
        {
            return _products;
        }
        public DogLeash GetDogLeashByName(string name)
        {
            try
            {
                return _dogLeashVariable[name];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CatFood GetCatFoodByName(string name)
        {
            try
            {
                return _catFoodVariable[name];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<string> GetOnlyInStockProducts()
            {
            return GetAllProducts().Instock();
            //return _products.Where(x => x.Quantity > 0).Select(x => x.Name).ToList();
            }
        public decimal GetTotalPriceOfInventory()
        {
            return _products.Where(x => x.Quantity > 0).Sum(x => x.Price * x.Quantity);
        }
        private List<Product> InitProducts()
            {
                return new List<Product>
             {
                new Product
                {
                    Name = "Purina ONE Tender Selects Blend with Real Salmon Dry Cat Food",
                    Price = 23.00m,
                    Description = "This easily digestible adult cat food helps support a microbiome balance in your feline friend and is made with natural prebiotic fiber to promote her gut health and immune support.",
                    Quantity = 15,
                },
                new Product
                {
                    Name = "Friskies Seafood Sensations Dry Cat Food",
                    Price = 27.00m,
                    Description = "Loaded with antioxidants to support a healthy immune system plus essential vitamins and minerals for overall well-being.",
                    Quantity = 12,
                },
                new Product
                {
                    Name = "Tiki Cat Born Carnivore High Protein Chicken, Herring & Salmon Meal Dry Cat Food.",
                    Price = 15.00m,
                    Description = "Crafted with real chicken and herring for the high-quality protein your kitty deserves.",
                    Quantity = 0,
                },
                new Product
                {
                    Name = "Meow Mix Original Choice Dry Cat Food",
                    Price = 15.00m,
                    Description = "Complete and balanced nutrition for adult cats.",
                    Quantity = 17,
                }
             };
            }

    }

}
