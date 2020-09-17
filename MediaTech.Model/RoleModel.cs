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
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public bool Status { get; set; }
    }
}
