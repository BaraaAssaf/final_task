using Core.Data;
using Core.Domain;
using Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace infra1.Repository
{
    public class usermessage_repository :Iusermesssage_Repository
    {
        private readonly IDBContext dBContext;

        public usermessage_repository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool Delete(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("userId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_UserMessage_Package.user_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;

        }

        public int totalofmessage(int userid) 
        {
            var count = GetAll().Where(X => X.userfrom == userid || X.userto == userid).Count();
            return count;
        
        
        
        }

        public List<API_UserMessage> GetAll()
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<API_UserMessage> result = dBContext.dbConnection.Query<API_UserMessage>
                ("API_UserMessage_Package.user_CRUD", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }


     

        public API_UserMessage Insert(API_UserMessage userMessage)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("mstatus", userMessage.status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("mdate", userMessage.datemasseage, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("ufrom", userMessage.userfrom, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("uto", userMessage.userto, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_UserMessage_Package.user_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return userMessage;
        }

        public bool Update(API_UserMessage userMessage)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                  ("userId", userMessage.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("mstatus", userMessage.status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("mdate", userMessage.datemasseage, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("ufrom", userMessage.userfrom, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("uto", userMessage.userto, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                  ("API_UserMessage_Package.user_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
    }
}
