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
    public class UserController : ControllerBase
    {

        private readonly Iuser_service iuser;
        public UserController(Iuser_service iuser)
        {
            this.iuser = iuser;

        }


        [HttpGet]
        [Route("countpostlike")]
        public IActionResult countcountry_user()
        {
            try
            {
                return Ok(iuser.countcountry_user());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("getweatherbyaddress/{id}")]
        public IActionResult getweatherbyaddress(int id)
        {
            string Address = iuser.getuseraddress(id); 
            return Redirect("http://api.weatherstack.com/current?access_key=0fa3d1b8484a3640869b047a9e2873c8&query=" + Address);

        }


        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
        {
            return iuser.Delete(id);
        }

        [HttpGet]
        public List<API_User> GetAll()
        {
            return iuser.GetAll();
        }
        [HttpPost]
        public API_User Insert([FromBody] API_User user)
        {
            return iuser.Insert(user);
        }
        [HttpPut]
        public bool Update([FromBody] API_User user)
        {
            return iuser.Update(user);
        }
    }
}
