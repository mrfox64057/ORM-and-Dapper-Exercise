
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;




namespace ORM_Dapper
{

    public class Program
    {

        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            
            var productRepo = new DapperProductRepository(conn);

            
            var productUpdate = productRepo.GetById(1);
            productUpdate.Name = "Lenovo Thinkpad Gen X";
            productUpdate.CategoryID = 1;
            productUpdate.OnSale = false;
            productUpdate.ProductID = 1;
            productUpdate.Price = 4000;

            productRepo.UpdateProduct(productUpdate);
            
            productRepo.UpdateProduct(productUpdate);

            var products = productRepo.GetAll();

            foreach (var product in products)

            {
                Console.WriteLine($"{product.ProductID}" + "\n"+$"{product.Name}"+"\n"+$"{product.Price}" + $"{product.CategoryID }" + "\n" + $"{ product.OnSale}" + "\n" + $"{product.StockLevel}");
            }


            #region departments
            ////var departments = new DapperDepartmentReposisitory(conn);

            ////departmentRepo.InsertDepartment("Adam's New Department");

            ////var departments = DapperDepartmentRepository.GetAll();

            ////foreach (var department in departments)
            ////{
            ////    Console.WriteLine($"{department.DepartmentID}"+"\n"+"{department.Name}"+"\n\n");
            ////}


            //void CreateProduct(string name, double price, int categoryID);


            ////var repo = DapperDepartmentRepository(conn);

            ////repo.CreateDepartment(Console.ReadLine());

            ////var departments = repo.GetAll();

            ////foreach (var department in departments)
            ////{
            ////    Console.WriteLine($"{department.DepartmentID} {department.Name}");
            ////}
            #endregion

        }
    }
}
