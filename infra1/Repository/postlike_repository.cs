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
    public class postlike_repository : Ipostlike_Repository
    {
        private readonly IDBContext dBContext;

        public postlike_repository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool Delete(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("postlikeId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_Postlike_Package.postlike_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;

        }
        public int countpostlike(int postid) 
        {
            var count = GetAll().Where(x => x.post_id == postid).Count();
            return count;

        }


        public List<API_Postlike> GetAll()
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<API_Postlike> result = dBContext.dbConnection.Query<API_Postlike>
                ("API_Postlike_Package.postlike_CRUD", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }

        public API_Postlike Insert(API_Postlike postlike)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
       
            parameter.Add("u_like", postlike.userlike_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("p_like",postlike.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_Postlike_Package.postlike_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return postlike;
        }

      

  

        public bool Update(API_Postlike postlike)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                  ("postlikeId", postlike.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("u_like", postlike.userlike_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("p_like", postlike.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

         
            var result = dBContext.dbConnection.ExecuteAsync
                  ("API_Postlike_Package.postlike_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
    }
}
