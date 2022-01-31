using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models.Database
{
    public class ProductHelper
    {
        public static IList<Product> GenerateProducts()
        {
            IList<Product> products = new List<Product>()
            {
                new Product() {
                    Name = "Kava",
                    Price = 100,
                    Content = "Mleta, 250g" },

                 new Product() {
                     Name = "Margotka",
                    Price = 20,
                    Content = "Kokosova" },

                  new Product() {
                    Name = "Banan",
                    Price = 25,
                    Content = "1kg" },

                  new Product() {
                    Name = "Kofola",
                    Price = 21,
                    Content = "Orginal, 2L" },
            };
            return products;
        }
    }
}
