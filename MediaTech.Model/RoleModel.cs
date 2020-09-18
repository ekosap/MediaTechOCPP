using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaTech.Model
{
    [Table("RoleDB")]
    public class RoleModel
    {
        [Key]
        public long RoleID { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int ModifyBy { get; set; }
        public bool Status { get; set; }
    }
}
