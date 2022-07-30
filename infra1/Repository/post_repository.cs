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
    public class post_repository : Ipost_Repository
    {
        private readonly IDBContext dBContext;



        public post_repository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool Delete(int postid)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("postId", postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_Post_Package.post_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;

        }

        public List<API_Post> GetAll()
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<API_Post> result = dBContext.dbConnection.Query<API_Post>
                ("API_Post_Package.post_CRUD", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }

        public API_Post Insert(API_Post post)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("text", post.post_text, dbType: DbType.String, direction: ParameterDirection.Input);
  
            parameter.Add("u_post", post.user_post, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_Post_Package.post_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return post;
        }


        public bool Update(API_Post post)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                  ("postId", post.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("text", post.post_text, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("u_post", post.user_post, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                  ("API_Post_Package.post_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
    }
}
