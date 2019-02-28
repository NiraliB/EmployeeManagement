using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModels.ViewModels
{

    public class DeptViewModel
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public bool IsDelete { get; set; }
    }


    public class DispDepartmentTable {
        public int RowIntCount { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
