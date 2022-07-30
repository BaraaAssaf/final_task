using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Final_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsermessageController : ControllerBase
    {


        private readonly Iusermessage_service iusermessage_Service;
        public UsermessageController(Iusermessage_service iusermessage_Service)
        {
            this.iusermessage_Service = iusermessage_Service;

        }

        [HttpGet]
        [Route("totalofmessage/{userid}")]
        public IActionResult totalofmessage(int userid)
        {
            try
            {
                return Ok(iusermessage_Service.totalofmessage(userid));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
        {
            return iusermessage_Service.Delete(id);
        }

        [HttpGet]
        public List<API_UserMessage> GetAll()
        {
            return iusermessage_Service.GetAll();
        }
        [HttpPost]
        public API_UserMessage Insert([FromBody] API_UserMessage userMessage)
        {
            return iusermessage_Service.Insert(userMessage);
        }
        [HttpPut]
        public bool Update([FromBody] API_UserMessage userMessage)
        {
            return iusermessage_Service.Update(userMessage);
        }


    }
}
