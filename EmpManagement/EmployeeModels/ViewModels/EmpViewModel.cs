using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModels.ViewModels
{
    public class EmpViewModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpSurname { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string ContactNumber { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
