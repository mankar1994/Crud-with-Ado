using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data;

namespace CURDADIO.Models
{
    public class EmployeeDataAccess
    {
        DBConnection Dbconnection;
        public EmployeeDataAccess()
        {
            Dbconnection = new DBConnection();
        }
        public List<EMPLOYEES> GetEMPLOYEES()
        {
            string Sp = "SP_EMPLOYEE";

            SqlCommand sql = new SqlCommand(Sp, Dbconnection.Connection);
           sql.Parameters.AddWithValue("@action", "SELECT_JOIN");
            if(Dbconnection.Connection.State==System.Data.ConnectionState.Closed)
            {
                Dbconnection.Connection.Open();
            }
            SqlDataReader dr = sql.ExecuteReader();
            List<EMPLOYEES> employees = new List<EMPLOYEES>();
            while(dr.Read())
            {
                EMPLOYEES Emp = new EMPLOYEES();
                Emp.Id = (int)dr["id"];
                Emp.Name = dr["name"].ToString();
                Emp.Email = dr["Email"].ToString();
                Emp.Mobile = dr["Mobile"].ToString();
                Emp.Gender = dr["Gender"].ToString();
                Emp.DName = dr["Department"].ToString();
                employees.Add(Emp);
            }
            Dbconnection.Connection.Close();
            return employees;
        }
            
            
    }
}
