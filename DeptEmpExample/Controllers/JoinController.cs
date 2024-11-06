using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeptEmpExample.Models;

namespace DeptEmpExample.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class JoinController : ControllerBase
    {
      DepartmentContext db=new DepartmentContext(); 

        [HttpGet]
        public Object GetJoinMethods()
        {
            var query = from emp in db.Employees
                        join dept in db.Departments on emp.DeptId equals dept.DeptId
                       
                        select new
                        {
                            EmpName = emp.EmpName,
                            DeptName = dept.DeptName,
                           
                        };
            return query;
        }
    }
}
