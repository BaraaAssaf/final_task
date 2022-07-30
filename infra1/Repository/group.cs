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
    public class group:Igroup_Repository
    {

        private readonly IDBContext dBContext;

        public group(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool Delete(int groupid)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("groupId ", groupid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_group_Package.group_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;

        }

        public List<API_group> GetAll()
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<API_group> result = dBContext.dbConnection.Query<API_group>
                ("API_group_Package.group_CRUD", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }

        public API_group Insert(API_group group)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("gname", group.group_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("MID", group.manegerofgroup, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_group_Package.group_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return group;
        }

        public bool Update(API_group group)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                  ("groupId", group.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("gname",group.group_name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("MID", group.manegerofgroup, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                  ("API_group_Package.group_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
    }
}
