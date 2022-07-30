using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class API_Post
    {
        [Key]
        public int id { get; set; }
        public string post_text { get; set; }

        public int user_post { get; set; }

        [ForeignKey("user_post")]
        public virtual API_User User { get; set; }

  



    }
}
