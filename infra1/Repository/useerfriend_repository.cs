
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
    public class useerfriend_repository : Iuserfriend_Repository
    {
        private readonly IDBContext dBContext;

        public useerfriend_repository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }






        public bool Delete(int userid)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("userfriendId", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_UserFriend_Package.userfriend_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;

        }

        public List<API_UserFriend> GetAll()
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<API_UserFriend> result = dBContext.dbConnection.Query<API_UserFriend>
                ("API_UserFriend_Package.userfriend_CRUD", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }

        public API_UserFriend Insert(API_UserFriend userFriend)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ustatus", userFriend.status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("UID2", userFriend.user_id2, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("UID1", userFriend.user_id1, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_UserFriend_Package.userfriend_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return userFriend;
        }




      


        public bool Update(API_UserFriend userFriend)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                  ("userfriendId", userFriend.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ustatus", userFriend.status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("UID2", userFriend.user_id2, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("UID1", userFriend.user_id1, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                  ("API_UserFriend_Package.userfriend_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
    }
}
