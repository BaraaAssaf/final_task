using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace infra1.Repository
{
    public class Useerfriend_service : Iuserfriend_service
    {
        private readonly Iuserfriend_Repository iuserfriend;
        public Useerfriend_service(Iuserfriend_Repository iuserfriend)
        {
            this.iuserfriend = iuserfriend;
        }

        public bool Delete(int userid)
        {
            return iuserfriend.Delete(userid);
        }

        public List<API_UserFriend> GetAll()
        {
            return iuserfriend.GetAll();
        }

        public API_UserFriend Insert(API_UserFriend userFriend)
        {
            return iuserfriend.Insert(userFriend);
        }

        public bool Update(API_UserFriend userFriend)
        {
            return iuserfriend.Update(userFriend);
        }
    }
}
