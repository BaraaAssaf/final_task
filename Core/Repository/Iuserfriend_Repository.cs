using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface Iuserfriend_Repository
    {
        public List<API_UserFriend> GetAll();
        public API_UserFriend Insert(API_UserFriend userFriend);
        public bool Delete(int userid);
        public bool Update(API_UserFriend userFriend);
    }
}
