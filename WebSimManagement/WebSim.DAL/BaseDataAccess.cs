using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSim.DAL
{
    /// <summary>
    /// Connect the project with the database
    /// </summary>
    public class BaseDataAccess
    {
        /// <summary>
        /// Static connection string to the databases
        /// </summary>
        protected static string connectionString = ConfigurationManager.ConnectionStrings["Websim_Database_ConnectionString"].ConnectionString;

    }
}
