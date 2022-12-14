using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
   public class API_User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public long phone { get; set; }

        //[Required]
        //[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-
        //  9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-
        //  ]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
        //ErrorMessage = "Please enter a valid e-mail adress")]
        public string email { get; set; }
        public string Address { get; set; }

    }
}

    
