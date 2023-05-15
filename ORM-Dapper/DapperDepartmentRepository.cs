using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository    
    {
        private readonly IDbConnection _conn;

        public DapperDepartmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Department> GetAll()
        {
            return _conn.Query<Department>("select * from departments;");

            //return _departmentRepository.GetAll();
        }

       

        //public IEnumerable<Department> Departments { get;}

        //public DapperDepartmentRepository() { }
    }
}
