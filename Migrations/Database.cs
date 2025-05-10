using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Dapper;
using Microsoft.Data.SqlClient;


namespace Migrations
{
    public static class Database
    {
        public static void Migrate(string Connectionstring ,string Name)
        {
            using var  Connection = new SqlConnection(Connectionstring);
            var parameters = new DynamicParameters();
            parameters.Add("name", Name);
            if (!Connection.Query("SELECT * FROM sys.database WHERE name=@name").Any())
            {
                Connection.Execute($"CREATE DATABASE `{Name}`");

            }
        }
    }
}
