using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class API_UserFriend
    {
        [Key]
        public int id { get; set; }
        public string status { get; set; }

        public int user_id1 { get; set; }

        [ForeignKey("user_id1")]
        public virtual API_User User { get; set; }

        public int user_id2 { get; set; }

        [ForeignKey("user_id2")]
        public virtual API_User User2 { get; set; }

   


    }
}



