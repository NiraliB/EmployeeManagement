using EmployeeModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModels
{
    public class EmployeeServices
    {
        private EmployeeManagementEntities empDb;

        public EmployeeServices()
        {
            empDb = new EmployeeManagementEntities();
        }

        public string SaveEmployeeData(EmpViewModel objEmpView)
        {
            try
            {
                Employee objEmpEntity = new Employee();

                if (objEmpView != null)
                {
                    objEmpEntity.EmpName = objEmpView.EmpName;
                    objEmpEntity.EmpSurname = objEmpView.EmpSurname;
                    objEmpEntity.Address = objEmpView.Address;
                    objEmpEntity.ContactNumber = objEmpView.ContactNumber;
                    objEmpEntity.DeptId = objEmpView.DeptId;
                    objEmpEntity.Qualification = objEmpView.Qualification;

                    if (objEmpView.EmpId == 0)
                    {
                        empDb.Entry(objEmpEntity).State = EntityState.Added;
                    }
                    else
                    {
                        objEmpEntity.EmpId = objEmpView.EmpId;
                        empDb.Entry(objEmpEntity).State = EntityState.Modified;
                        //empDb.Entry(objEnDept).Property(x => x.IsDelete).IsModified = false;
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

        public List<DeptViewModel> GetDepartmentListDDL()
        {
            try
            {
                var getDepList = (from d in empDb.Departments
                                  where (d.IsDelete == false)
                                  select new DeptViewModel
                                  {
                                      DeptId = d.DeptId,
                                      DeptName = d.DeptName
                                  }).ToList();

                return getDepList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmpViewModel GetEditDataOnId(int Id)
        {
            try
            {
                var objEmpRec = (from d in empDb.Employees
                                 where (d.EmpId == Id)
                                 select new EmpViewModel
                                 {
                                     EmpId = d.EmpId,
                                     EmpName = d.EmpName,
                                     EmpSurname = d.EmpSurname,
                                     Qualification = d.Qualification,
                                     ContactNumber = d.ContactNumber,
                                     Address = d.Address,
                                     DeptId = d.DeptId
                                 }).FirstOrDefault();

                return objEmpRec;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmpViewModel> GetEmpDataOnLoad()
        {
            try
            {
                var objEmpRecList = (from d in empDb.Employees
                                     join dep in empDb.Departments on d.DeptId equals dep.DeptId
                                     where (dep.IsDelete == false)
                                     select new EmpViewModel
                                     {
                                         EmpId = d.EmpId,
                                         EmpName = d.EmpName,
                                         EmpSurname = d.EmpSurname,
                                         Qualification = d.Qualification,
                                         ContactNumber = d.ContactNumber,
                                         Address = d.Address,
                                         DeptName = dep.DeptName
                                     }).ToList();

                return objEmpRecList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteEmployeesOnId(int Id)
        {
            try
            {
                var getEmpData = empDb.Employees.Where(s => s.EmpId == Id).FirstOrDefault();
                if (getEmpData != null)
                {
                    empDb.Entry(getEmpData).State = EntityState.Deleted;
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

    }
}
