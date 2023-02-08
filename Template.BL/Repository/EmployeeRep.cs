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
            var data = db.Employee.ToList();
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
            int action= db.SaveChanges();
            if(action>0)
            return db.Employee.OrderBy(a => a.Id).LastOrDefault();

            throw new Exception("ex.Message");
        }

        public Employee Update(Employee model)
        {

            var entity = db.Employee.Find(model.Id);
            db.Entry(entity).State = EntityState.Detached;
            if (entity is null)
                throw new Exception("Employee not found");
            model.CreationDate = entity.CreationDate;

            db.Entry(model).State = EntityState.Modified;
            int action = db.SaveChanges();
            if (action > 0)
                return model;
            throw new Exception("ex.Message");
        }

        public Employee Delete(int id)
        {
            var OldData = db.Employee.Find(id);
            if (OldData is null)
                throw new Exception("Employee not found");

            db.Employee.Remove(OldData);
            int action = db.SaveChanges();
            if (action > 0)
                return OldData;

            throw new Exception("ex.Message");
        }

    }
}
