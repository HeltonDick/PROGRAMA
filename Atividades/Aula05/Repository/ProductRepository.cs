using Modelo;
using System.Xml.Linq;

namespace Repository
{
    public class ProductRepository {
        public Product Retrive(int id)
        {
            foreach (Product p in CustomerData.Products) {
                if (p.Id == id) { 
                    return p;
                }
            }
            return null;
        }

        public List<Product> RetriveByName( string name) {
            List<Product> ret = new List<Product>();

            foreach (Product p in CustomerData.Products) {
                if (p.Name!.ToLower().Contains(name.ToLower()))
                    ret.Add(p);

                return ret;
            }
            return null;
        }

        public List<Product> RetrieveAll() {
            return CustomerData.Products;
        }

        public void Save(Product product) {
            product.Id = GetCount() + 1;
            CustomerData.Products.Add(product);
        }

        public int GetCount()
        {
            return CustomerData.Customers.Count;
        }
    }
}
