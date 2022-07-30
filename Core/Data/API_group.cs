using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class API_group
    {
        [Key]
        public int id { get; set; }
        public string group_name { get; set; }

        public int manegerofgroup { get; set; }

        [ForeignKey("manegerofgroup")]
        public virtual API_User User { get; set; }
     

    }
}


