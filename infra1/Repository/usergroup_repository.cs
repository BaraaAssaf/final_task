using Core.Data;
using Core.Domain;
using Core.Repository;
using Dapper;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace infra1.Repository
{
    public class usergroup_repository : Iuser_group_Repository
    {
        private readonly IDBContext dBContext;

        public usergroup_repository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool Delete(int id)
        {

            var parameter = new DynamicParameters();

            parameter.Add("crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("usergroupId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_UserGroup_Package.userGroup_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;

        }

        public List<API_UserGroup> GetAll()
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<API_UserGroup> result = dBContext.dbConnection.Query<API_UserGroup>
                ("API_UserGroup_Package.userGroup_CRUD", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();


        }

        public API_UserGroup Insert(API_UserGroup userGroup)
        {
            var parameter = new DynamicParameters();

            parameter.Add("crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ustatus", userGroup.status, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("UID", userGroup.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            parameter.Add("GID", userGroup.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_UserGroup_Package.userGroup_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return userGroup;
        }


 

        public bool Update(API_UserGroup userGroup)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                  ("usergroupId", userGroup.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ustatus", userGroup.status, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("UID", userGroup.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            parameter.Add("GID", userGroup.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                  ("API_UserGroup_Package.userGroup_CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool userblock(int groupid, int userblock, int useridblocked) 
        {

            var parameter = new DynamicParameters();
            parameter.Add
                  ("usergroupId", 1 , dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ustatus","blocked" , dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("UID",useridblocked , dbType: DbType.Int32, direction: ParameterDirection.Input);


            parameter.Add("GID", groupid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                  ("API_UserGroup_Package.userGroup_CRUD", parameter, commandType: CommandType.StoredProcedure);

         
            
       
        var user1 = iuser.GetAll().Where(x => x.id == userblock).FirstOrDefault();
            var user2 = iuser.GetAll().Where(x => x.id == useridblocked).FirstOrDefault();

            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("User", "tessssssssst4@outlook.com");

            MailboxAddress to = new MailboxAddress("user", user2.email);

            builder.HtmlBody = "<h1>" +user1.name +"  Block  "+ user2.name + "</h1>";

            message.Body = builder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = "checking";
            using (var item = new SmtpClient())
            {
              
                item.Connect("smtp.office365.com", 587, false);
                item.Authenticate("tessssssssst4@outlook.com", "Test@123456789");
                item.Send(message);
                item.Disconnect(true);

            }

       
       


            return true;
        }

    }
}
