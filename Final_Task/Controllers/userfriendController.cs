using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userfriendController : ControllerBase
    {
        private readonly Iuserfriend_service iuserfriend;
        public userfriendController(Iuserfriend_service iuserfriend)
        {
            this.iuserfriend = iuserfriend;

        }


        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
        {
            return iuserfriend.Delete(id);
        }

        [HttpGet]
        public List<API_UserFriend> GetAll()
        {
            return iuserfriend.GetAll();
        }
        [HttpPost]
        public API_UserFriend Insert([FromBody] API_UserFriend userFriend)
        {
            return iuserfriend.Insert(userFriend);
        }
        [HttpPut]
        public bool Update([FromBody] API_UserFriend userFriend)
        {
            return iuserfriend.Update(userFriend);
        }


    }
}
