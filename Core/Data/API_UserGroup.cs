using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class API_UserGroup
    {
        [Key]
        public int id { get; set; }
       
        public string status { get; set; }

        public int group_id { get; set; }
        public int user_id { get; set; }


        [ForeignKey("group_id")]
        public virtual API_group Group { get; set; }


        [ForeignKey("user_id")]
        public virtual API_User User { get; set; }


    }
}


