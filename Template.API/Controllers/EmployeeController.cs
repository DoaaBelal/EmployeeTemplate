using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.BL.Helper;
using Template.BL.Interface;
using Template.BL.Models;
using Template.DAL.Entity;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Fields
        private readonly IEmployeeRep employee;
        private readonly IMapper mapper;
        #endregion

        #region Ctor
        public EmployeeController(IEmployeeRep employee, IMapper mapper)
        {
            this.employee = employee;
            this.mapper = mapper;
        }
        #endregion

        #region APIs

        [Route("~/API/Employee/GetEmployees")]
        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var Data = employee.Get();
                var model = mapper.Map<IEnumerable<EmployeeVM>>(Data);
                return Ok(new ApiResponse<IEnumerable<EmployeeVM>>() {
                    Code= "200",
                    Status="OK",
                    Message="Data Retrieved",
                    Response=model

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "BadRequest",
                    Message = "Error Occur when get data",
                    Response = ex.Message
                });
            }
        }

        [Route("~/API/Employee/GetEmployeeById/{id}")]
        [HttpGet]
        public IActionResult GetEmployeeById(int? id)
        {
            try
            {
                if (!id.HasValue)
                    throw new Exception("Employee ID is required");

                var Data = employee.GetById(a => a.Id == id.Value);
                var model = mapper.Map<EmployeeVM>(Data);
                return Ok(new ApiResponse<EmployeeVM>()
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Data Retrieved",
                    Response = model

                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "NotFound",
                    Message = "Data Not Found",
                    Response = ex.Message
                });
            }
        }

        [Route("~/API/Employee/PostData")]
        [HttpPost]
         public IActionResult PostData(EmployeeVM model)
         {
            try
            {
                if (ModelState.IsValid)
                {
                    var Data = mapper.Map<Employee>(model);
                    var Result = employee.Create(Data);
                    return Ok(new ApiResponse<Employee>() {
                        Code = "200",
                        Status = "Created",
                        Message = "Data Created",
                        Response = Result
                    });
                }
                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = "Data Not Created",
                    Response = "Invalid Object"
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = "Data Not Created",
                    Response = ex.Message
                });
            }
        }

        [Route("~/API/Employee/PutData")]
        [HttpPut]
        public IActionResult PutData(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Data = mapper.Map<Employee>(model);
                    var Result = employee.Update(Data);
                    return Ok(new ApiResponse<Employee>()
                    {
                        Code = "200",
                        Status = "Updated",
                        Message = "Data Updated",
                        Response = Result
                    });
                }
                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = "Data Not Updated",
                    Response = "Invalid Object"
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = "Data Not Updated",
                    Response = ex.Message
                });
            }
        }

        [Route("~/API/Employee/DeleteData/{id}")]
        [HttpDelete]
        public IActionResult DeleteData(int? id)
        {
            try
            {
                if (!id.HasValue)
                    throw new Exception("Employee ID is required");
                    var Result = employee.Delete(id.Value);
                    return Ok(new ApiResponse<Employee>()
                    {
                        Code = "200",
                        Status = "Deleted",
                        Message = "Data Deleted",
                        Response = Result
                    });
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = "Data Not Deleted",
                    Response = ex.Message
                });
            }
        }
        #endregion


    }
}
