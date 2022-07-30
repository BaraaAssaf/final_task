using Core.Data;
using Core.Domain;
using Core.DTO;
using Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace infra1.Repository
{
    public class USER_REPOSITORY : Iuser_Repository
    {
        private readonly IDBContext dBContext;

        public USER_REPOSITORY(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool Delete(int user)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("UserId", user, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_User_Package.user_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;

        }

        public string getuseraddress(int id) 
        {
            var Address = GetAll().Where(x => x.id == id).FirstOrDefault().Address;

            return Address;
        }

        public List<User_Dto> countcountry_user() 
        {
            IEnumerable<User_Dto> result = dBContext.dbConnection.Query<User_Dto>
               ("API_User_Package.countAddress", commandType: System.Data.CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<API_User> GetAll()
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<API_User> result = dBContext.dbConnection.Query<API_User>
                ("API_User_Package.user_CRUD", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }

        public API_User Insert(API_User user)
        {

            string[] eemail = {"outlook.com" , "hotmail.com", "gmail.com" , "yahoo.com" };
            string[] Address = { "Irbid", "Amman", "Zarqa", "Aqaba" };
            string path = @"C:\Users\BARAA\source\repos\final_task\infra1\Text\emp.txt";
         var lines = File.ReadAllLines(path);
            var r = new Random();
            var randomLineNumber = r.Next(0, lines.Length - 1);
            user.name  = lines[randomLineNumber];
            user.email = user.name + "@" + eemail[r.Next(3)];
            user.Address = Address[r.Next(3)];
            user.phone = 33333;

            var parameter = new DynamicParameters();

            parameter.Add("crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Uname", user.name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("uphone", user.phone, dbType: DbType.Int64, direction: ParameterDirection.Input);
            parameter.Add("uemail", user.email, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("uaddress", user.email, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_User_Package.user_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return user;
        }


        public bool Update(API_User user)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                  ("UserId", user.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Uname", user.name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("uphone", user.phone, dbType: DbType.Int64, direction: ParameterDirection.Input);
            parameter.Add("uemail", user.email, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("uaddress", user.email, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                  ("API_User_Package.user_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
    }
}
