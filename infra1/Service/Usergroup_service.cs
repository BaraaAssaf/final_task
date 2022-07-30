using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace infra1.Repository
{
    public class Usergroup_service : Iusergroup_service
    {
        private readonly Iuser_group_Repository iuser_Group;
        public Usergroup_service(Iuser_group_Repository iuser_Group)
        {
            this.iuser_Group = iuser_Group;
        }

        public bool userblock(int groupid, int userblock, int useridblocked) 
        {
            return iuser_Group.userblock(groupid, userblock, useridblocked);
        }
        public bool Delete(int id)
        {
            return iuser_Group.Delete(id);
        }

       public List<API_UserGroup> GetAll()
        {
            return iuser_Group.GetAll();
        }

       public API_UserGroup Insert(API_UserGroup userGroup)
        {
            return iuser_Group.Insert(userGroup);
        }

        public  bool Update(API_UserGroup userGroup)
        {
            return iuser_Group.Update(userGroup);
        }
    }
}
