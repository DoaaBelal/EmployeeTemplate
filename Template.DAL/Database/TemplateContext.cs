using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DAL.Entity;

namespace Template.DAL.Database
{
    public class TemplateContext : DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> opt) : base(opt)
        {

        }
        public DbSet<Employee> Employee { get; set; }

    }
}
