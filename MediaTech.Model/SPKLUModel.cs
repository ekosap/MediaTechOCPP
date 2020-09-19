using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediaTech.Model
{
    [Table("SPKLU")]
    public class SPKLUModel
    {
        [Key]
        public int SPKLUId { get; set; }
        public string SPKLUName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int ModifyBy { get; set; }
        public bool Status { get; set; }
        public bool IsACType { get; set; }
        public string Alamat { get; set; }
    }
}
