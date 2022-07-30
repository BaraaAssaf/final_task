using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly Iusergroup_service iusergroup;
        public UserGroupController(Iusergroup_service iusergroup)
        {
            this.iusergroup = iusergroup;

        }


        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
        {
            return iusergroup.Delete(id);
        }

        [HttpGet]
        public List<API_UserGroup> GetAll()
        {
            return iusergroup.GetAll();
        }
        [HttpPost]
        public API_UserGroup Insert([FromBody] API_UserGroup userGroup)
        {
            return iusergroup.Insert(userGroup);
        }
        [HttpPut]
        public bool Update([FromBody] API_UserGroup userGroup)
        {
            return iusergroup.Update(userGroup);
        }


        [HttpPut("userblock/{groupid}/{userblock}/{useridblocked}")]
        public bool userblock(int groupid, int userblock, int useridblocked) 
        {
            return iusergroup.userblock(groupid,userblock,useridblocked);
        }

      


    }
}
