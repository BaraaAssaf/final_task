using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class postController : ControllerBase
    {

        private readonly Ipost_service ipost;
        public postController(Ipost_service ipost)
        {
            this.ipost = ipost;

        }


        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
        {
            return ipost.Delete(id);
        }

        [HttpGet]
        public List<API_Post> GetAll()
        {
            return ipost.GetAll();
        }
        [HttpPost]
        public API_Post Insert([FromBody] API_Post post)
        {
            return ipost.Insert(post);
        }
        [HttpPut]
        public bool Update([FromBody] API_Post post )
        {
            return ipost.Update(post);
        }


    }
}
