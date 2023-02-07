using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.BL.Interface;
using Template.DAL.Database;
using Template.DAL.Entity;

namespace Template.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        
        private readonly TemplateContext db;

        public EmployeeRep(TemplateContext db)
        {
            this.db = db;
        }


        public IEnumerable<Employee> Get()
        {
                var data = db.Employee.Select(a => a);
                return data;
        }

        public Employee GetById(Expression<Func<Employee, bool>> filter = null)
        {
            var data = db.Employee.Where(filter).FirstOrDefault();
            return data;
        }

        public Employee Create(Employee model)
        {
            db.Employee.Add(model);
            db.SaveChanges();
            return db.Employee.OrderBy(a => a.Id).LastOrDefault();
        }

        public Employee Update(Employee model)
        {

            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return db.Employee.Where(a => a.Id == model.Id).FirstOrDefault();
        }

        public Employee Delete(int id)
        {
            var OldData = db.Employee.Find(id);
            db.Employee.Remove(OldData);
            db.SaveChanges();
            return OldData;
        }

    }
}
