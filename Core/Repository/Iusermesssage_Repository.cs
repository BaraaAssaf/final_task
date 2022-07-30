using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface Iusermesssage_Repository
    {
        public List<API_UserMessage> GetAll();
        public API_UserMessage Insert(API_UserMessage userMessage);
        public bool Delete(int id);
        public bool Update(API_UserMessage userMessage);


        public int totalofmessage(int userid);
    }

}
