using EmployeeModels;
using EmployeeModels.ViewModels;
using EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeManagementEntities empDb;
        private EmployeeServices _empService;

        public EmployeeController()
        {
            empDb = new EmployeeManagementEntities();
            _empService = new EmployeeServices();
        }

        [HttpGet]
        [Route("api/Employee/GetDepartmentNameListDDL")]
        public HttpResponseMessage GetDepartmentNameListDDL()
        {
            try
            {
                var lstDept = _empService.GetDepartmentListDDL();
                if (lstDept != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lstDept);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Employee list is not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Employee/SaveEmployeeData")]
        public HttpResponseMessage SaveEmployeeData(EmpViewModel objEmpView)
        {
            try
            {
                if (objEmpView != null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.OK, _empService.SaveEmployeeData(objEmpView));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Saved");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/Employee/GetEmployeeDataOnLoad")]
        public HttpResponseMessage GetEmployeeDataOnLoad()
        {
            try
            {
                var lstEmployees = _empService.GetEmpDataOnLoad();
                if (lstEmployees != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lstEmployees);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Department list is not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Employee/GetEmployeeRecordOnId")]
        public HttpResponseMessage GetEmployeeRecordOnId(int Id)
        {
            try
            {
                var lstDispEmp = _empService.GetEditDataOnId(Id);
                if (lstDispEmp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lstDispEmp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Employee list is not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Employee/DeleteEmployeeOnId")]
        public HttpResponseMessage DeleteEmployeeOnId(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, _empService.DeleteEmployeesOnId(Id));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Id is not getting");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
