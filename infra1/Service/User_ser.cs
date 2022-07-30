using Core.Data;
using Core.DTO;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace infra1.Service
{
    public class User_ser : Iuser_service
    {
        private readonly Iuser_Repository iuser;
        public User_ser(Iuser_Repository iuser)
        {
            this.iuser = iuser;
        }

        public bool Delete(int userid)
        {
            return iuser.Delete(userid);
        }
        public List<User_Dto> countcountry_user() 
        {

            return iuser.countcountry_user();

        }

        public string getuseraddress(int id)
        {
            return iuser.getuseraddress(id);
        }

        public List<API_User> GetAll()
        {
            return iuser.GetAll();
        }

        public API_User Insert(API_User user)
        {
            return iuser.Insert(user);
        }

        public bool Update(API_User user)
        {
            return iuser.Update(user);
        }
    }
}