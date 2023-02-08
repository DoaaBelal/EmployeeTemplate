using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.BL.Models;
using Template.DAL.Entity;

namespace Template.BL.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {

            CreateMap<Employee, EmployeeVM>().ReverseMap();

        }
    }
}
