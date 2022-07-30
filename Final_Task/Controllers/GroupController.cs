using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        private readonly Igroup_service igroup;
        public GroupController(Igroup_service igroup)
        {
            this.igroup = igroup;

        }


        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
        {
            return igroup.Delete(id);
        }

        [HttpGet]
        public List<API_group> GetAll()
        {
            return igroup.GetAll();
        }
        [HttpPost]
        public API_group Insert([FromBody] API_group group)
        {
            return igroup.Insert(group);
        }
        [HttpPut]
        public bool Update([FromBody] API_group group)
        {
            return igroup.Update(group);
        }

    }
}
