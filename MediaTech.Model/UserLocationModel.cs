using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediaTech.Model
{

    [Table("UserLocationDB")]
    public class UserLocationModel
    {
        [Key]
        public int UserLocationId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
    }
}
