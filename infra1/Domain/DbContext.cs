
using Core.Domain;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace infra1.Domain
{
    public class DbContext : IDBContext
    {
        private DbConnection connection;
        private readonly IConfiguration configuration;

        public DbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbConnection dbConnection
        {
            get
            {
                if (connection == null)
                {
                    connection = new OracleConnection(configuration["ConnectionStrings:DefaultConnection"]);
                    connection.Open();
                }
                else if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                return connection;
            }
        }
    }
}