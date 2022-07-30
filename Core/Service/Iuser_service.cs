using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface Iuser_service
    {
        public List<API_User> GetAll();
        public API_User Insert(API_User user);
        public bool Delete(int userid);
        public bool Update(API_User user);

        public string getuseraddress(int id);
        public List<User_Dto> countcountry_user();
    }
}
