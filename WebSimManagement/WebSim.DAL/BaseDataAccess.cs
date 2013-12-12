using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSim.DAL
{
    public class BaseDataAccess
    {
        protected static string connectionString = ConfigurationManager.ConnectionStrings["Websim_Database_ConnectionString"].ConnectionString;

    }
}
