using System.Collections;
using System.Collections.Generic;

namespace POS
{
    class DictionaryProductRepository : IProductRepository, IEnumerable<Product>
    {
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        public void Add(Product p)
        {
            products.Add(p.Code, p);
        }

        public double GetPrice(string productCode)
        {
            return products[productCode].Price;
        }

        public bool IsProvincial(string productCode)
        {
            return products[productCode].IsProvincial;
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return products.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}