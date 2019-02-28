using EmployeeModels;
using EmployeeModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace EmployeeService
{
    public class DepartmentService : CommonEntityService
    {
        private EmployeeManagementEntities empDb;

        public DepartmentService()
        {
            empDb = new EmployeeManagementEntities();
        }

        public string SaveDepartmentData(DeptViewModel objDeptView)
        {
            try
            {
                Department objEnDept = new Department();
                if (objDeptView != null)
                {
                    objEnDept.DeptName = objDeptView.DeptName;

                    if (objDeptView.DeptId == 0)
                    {
                        empDb.Entry(objEnDept).State = EntityState.Added;
                    }
                    else
                    {
                        objEnDept.DeptId = objDeptView.DeptId;
                        empDb.Entry(objEnDept).State = EntityState.Modified;
                        empDb.Entry(objEnDept).Property(x => x.IsDelete).IsModified = false;
                    }
                    empDb.SaveChanges();

                    return "SavedSuccessfully";
                }
                else
                {
                    return "SomethingWrong";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DeptViewModel> GetDeptDispData()
        {
            try
            {
                var objDepRecList = (from d in empDb.Departments
                                     where (d.IsDelete == false)
                                     select new DeptViewModel
                                     {
                                         DeptId = d.DeptId,
                                         DeptName = d.DeptName
                                     }).ToList();

                return objDepRecList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DeptViewModel GetEditDataOnId(int Id)
        {
            try
            {
                using (var context = new EmployeeManagementEntities())
                {

                    var objDept = (from d in context.Departments
                                   where (d.DeptId == Id)
                                   select new DeptViewModel
                                   {
                                       DeptId = d.DeptId,
                                       DeptName = d.DeptName
                                   }).FirstOrDefault();

                    return objDept;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteDepartmentOnId(int Id)
        {
            try
            {
                var getDeptData = empDb.Departments.Where(s => s.DeptId == Id).FirstOrDefault();
                if (getDeptData != null)
                {
                    getDeptData.IsDelete = true;
                    empDb.Entry(getDeptData).State = EntityState.Modified;
                    empDb.SaveChanges();
                    return "Deleted";
                }
                else
                {
                    return "NotDeleted";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public DataTable GetConvertDataTable()
        //{
        //    var dt = new DataTable();
        //    var conn = empDb.Database.Connection;
        //    var connectionState = conn.State;

        //    if (connectionState != ConnectionState.Open)
        //    {
        //        conn.Open();
        //    }

        //    using (var cmd = conn.CreateCommand())
        //    {
        //        cmd.CommandText = "Get_DepartmentList";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.Parameters.Add(new SqlParameter("jobCardId", 100525));
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            dt.Load(reader);
        //        }

        //        return dt;
        //    }
        //}

    }
}
