using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface Iuser_group_Repository
    {
        public List<API_UserGroup> GetAll();
        public API_UserGroup Insert(API_UserGroup userGroup);
        public bool Delete(int id);
        public bool Update(API_UserGroup userGroup);

        public bool userblock(int groupid ,int userblock, int useridblocked);


    }
}
