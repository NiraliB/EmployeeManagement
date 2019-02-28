using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class CommonEntityService
    {
        private EmployeeManagementEntities empDb;

        public CommonEntityService()
        {
            empDb = new EmployeeManagementEntities();
        }

        protected List<T> GetSpResult<T>(string SpName)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeManagementEntities"].ConnectionString;
            SqlConnection sql = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(SpName, sql)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Clear();
            sql.Open();
            var reader = cmd.ExecuteReader();

            var result = ((IObjectContextAdapter)empDb).ObjectContext.Translate<T>(reader).ToList();

            sql.Close();
            cmd.Dispose();
            return result;
            

        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
