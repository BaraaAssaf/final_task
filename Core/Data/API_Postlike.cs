using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class API_Postlike
    {
        [Key]
        public int id { get; set; }

        public int userlike_id { get; set; }

        [ForeignKey("userlike_id")]
        public virtual API_User User { get; set; }

        public int post_id { get; set; }

        [ForeignKey("post_id")]
        public virtual API_Post Post { get; set; }


       

    }
}
