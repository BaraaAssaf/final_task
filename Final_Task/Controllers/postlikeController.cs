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
    public class postlikeController : ControllerBase
    {


        private readonly Ipostlike_service ipostlike;
        public postlikeController(Ipostlike_service ipostlike)
        {
            this.ipostlike = ipostlike;

        }

        [HttpGet]
        [Route("countpostlike/{postid}")]
        public IActionResult countpostlike(int postid)
        {
            try
            {
                return Ok(ipostlike.countpostlike(postid));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
        {
            return ipostlike.Delete(id);
        }

        [HttpGet]
        public List<API_Postlike> GetAll()
        {
            return ipostlike.GetAll();
        }
        [HttpPost]
        public API_Postlike Insert([FromBody] API_Postlike postlike)
        {
            return ipostlike.Insert(postlike);
        }
        [HttpPut]
        public bool Update([FromBody] API_Postlike postlike)
        {
            return ipostlike.Update(postlike);
        }

    }
}
