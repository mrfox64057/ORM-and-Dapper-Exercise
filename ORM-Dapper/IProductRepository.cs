using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public void UpdateProduct (Product product); 
        public void DeleteProduct (int id);
    }
}
