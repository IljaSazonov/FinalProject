using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace RestWebService.Database
{
    public abstract class DbConnection
    {

        protected SQLiteConnection Con { get; set; }

        protected void Connect()
        {
            Con = new SQLiteConnection(@"Data Source=database.db;");
            if (Con.State != System.Data.ConnectionState.Open)
            {
                Con.Open();
            }
        }

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