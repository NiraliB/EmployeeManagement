using EmployeeModels;
using EmployeeModels.ViewModels;
using EmployeeService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class DepartmentController : ApiController
    {
        private EmployeeManagementEntities empDb;
        private DepartmentService _departmentService;

        public DepartmentController()
        {
            empDb = new EmployeeManagementEntities();
            _departmentService = new DepartmentService();
        }

        [HttpPost]
        [Route("api/Department/SaveDepartment")]
        public HttpResponseMessage SaveDeptData(DeptViewModel objDeptView)
        {
            try
            {
                if (objDeptView != null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.OK, _departmentService.SaveDepartmentData(objDeptView));
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
        [Route("api/Department/GetDisplayDepartmentData")]
        public HttpResponseMessage GetDisplayDepartmentData()
        {
            try
            {
                var lstDept = _departmentService.GetDeptDispData();
                if (lstDept != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lstDept);
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
        [Route("api/Department/GetEditDeptData")]
        public HttpResponseMessage GetEditDeptData(int Id)
        {
            try
            {
                var lstDispDept = _departmentService.GetEditDataOnId(Id);
                if (lstDispDept != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lstDispDept);
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
        [Route("api/Employee/DeleteDepartmentOnId")]
        public HttpResponseMessage DeleteDepartmentOnId(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, _departmentService.DeleteDepartmentOnId(Id));
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
