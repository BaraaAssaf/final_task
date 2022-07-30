using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace infra1.Repository
{
    public class Usermessage_service :Iusermessage_service
    {
        private readonly Iusermesssage_Repository iusermesssage;
        public Usermessage_service(Iusermesssage_Repository iusermesssage)
        {
            this.iusermesssage = iusermesssage;
        }

        public bool Delete(int id)
        {
            return iusermesssage.Delete(id);
        }

        public List<API_UserMessage> GetAll()
        {
            return iusermesssage.GetAll();
        }
        public int totalofmessage(int userid) 
        {
            return iusermesssage.totalofmessage(userid);
        }
        public API_UserMessage Insert(API_UserMessage userMessage)
        {
            return iusermesssage.Insert(userMessage);
        }

        public bool Update(API_UserMessage userMessage)
        {
            return iusermesssage.Update(userMessage);
        }
    }
}
