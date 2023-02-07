using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.DAL.Entity;

namespace Template.BL.Interface
{
    public interface IEmployeeRep
    {
        IEnumerable<Employee> Get();
        Employee GetById(Expression<Func<Employee, bool>> filter = null);
        Employee Create(Employee model);
        Employee Update(Employee model);
        Employee Delete(int id);
    }
}
