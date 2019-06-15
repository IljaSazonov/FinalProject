using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace RestWebService.Database
{
    /// <summary>
    /// Database connection class
    /// </summary>
    public abstract class DbConnection
    {


        /// <summary>
        /// Database connection
        /// </summary>
        protected SQLiteConnection Con { get; set; }

        /// <summary>
        /// Start connection to database
        /// </summary>
        protected void Connect()
        {
            Con = new SQLiteConnection(@"Data Source=database.db;");
            if (Con.State != System.Data.ConnectionState.Open)
            {
                Con.Open();
            }
        }


        /// <summary>
        /// End connection to database
        /// </summary>
        protected void Disconnect()
        {
            if (Con != null)
            {
                if (Con.State == System.Data.ConnectionState.Open)
                    Con.Close();
            }
        }

    }
}