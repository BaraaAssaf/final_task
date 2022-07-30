using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class API_UserMessage
    {

        [Key]
        public int id { get; set; }
        public string status { get; set; }

        public int userfrom { get; set; }

        public DateTime datemasseage { get; set; }

        [ForeignKey("userfrom")]
        public virtual API_User User { get; set; }

        public int userto { get; set; }

        [ForeignKey("userto")]
        public virtual API_User User2 { get; set; }

    }
}
