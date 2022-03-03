using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CURDADIO.Models
{
    public class DBConnection
    {
        public SqlConnection Connection;  
        public DBConnection ()
        {
            Connection = new SqlConnection(DBConfig.ConnectionStr);


        }
    }
}
