using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Product> GetAll()
        {
            return _conn.Query<Product>("select * from products;");
        }

        public Product GetById(int id)
        {
            return _conn.QuerySingle<Product>("select * from products where ProductID = @id;",
            new { id = id });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("update products " +
                          "set Name = @name, " +
                          "Price = @price, " +
                          "CategoryID = @catID, " +
                          "OnSAle = @onSAle, " +
                          "StockLevel = @stock",
                          new
                          {
                              name = product.Name,
                              price = product.Price,
                              catID = product.CategoryID,
                              onSale = product.OnSale,
                              stock = product.StockLevel
                          });


        }
        public void DeleteProduct(int id)
        {
            //throw new NotImplementedException();
            ////_conn.Execute("delete from Name where ProductID = @id;" new { id = id });
            ////_conn.Execute("delete from Price where ProductID = @id;" new { id = id });
            _conn.Execute("delete from Sales where ProductID = @id;", new { id2 = id });
            _conn.Execute("delete from Products where ProductID = @id;", new { id2 = id });
            _conn.Execute("delete from Reviews where ProductID = @id;", new { id2 = id });
            //    _conn.Execute(DeletedRowInaccessibleException fom)     What is DeletedRowInacessibleExcemtion from ?
        }
    }
}
