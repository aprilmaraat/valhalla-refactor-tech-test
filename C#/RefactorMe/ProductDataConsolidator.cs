using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.Enum;

namespace RefactorMe
{
    public class ProductDataConsolidator
    {
        /// <summary>
        /// Get list of products with unconverted price currency
        /// </summary>
        /// <returns>List of <see cref="Product"/></returns>
        public static List<Product> Get() {
            return GenerateProductList();
        }

        /// <summary>
        /// Get list of products with converted price currency to Euro
        /// </summary>
        /// <returns>List of <see cref="Product"/></returns>
        public static List<Product> GetInEuros() {
            return GenerateProductList(0.67);
        }

        /// <summary>
        /// Get list of products with converted price currency to Dollar
        /// </summary>
        /// <returns>List of <see cref="Product"/></returns>
        public static List<Product> GetInUSDollars()
        {
            return GenerateProductList(0.76);
        }

        /// <summary>
        /// Generates a list of products from multiple repository data
        /// </summary>
        /// <param name="currencyMultiplier">Currency multiplier: Price is multiplied with the paramater, if not provided defaults to 1</param>
        /// <returns>List of <see cref="Product"/></returns>
        private static List<Product> GenerateProductList(double currencyMultiplier = 1)
        {
            IQueryable<Lawnmower> lawnmowers = new LawnmowerRepository().GetAll();
            IQueryable<PhoneCase> phoneCases = new PhoneCaseRepository().GetAll();
            IQueryable<TShirt> tShirts = new TShirtRepository().GetAll();

            var products = new List<Product>();
            products.AddRange(
                lawnmowers.Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price * currencyMultiplier,
                    Type = EnumItemType.Lawnmower.ToString()
                })
                .Concat(
                    phoneCases.Select(x => new Product
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price * currencyMultiplier,
                        Type = EnumItemType.PhoneCase.ToString()
                    })
                ).Concat(
                    tShirts.Select(x => new Product
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price * currencyMultiplier,
                        Type = EnumItemType.TShirt.ToString()
                    })
                ));

            return products;
        }
    }
}
