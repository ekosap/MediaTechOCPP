using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediaTech.Model
{
    [Table("SKPLU")]
    public class SKPLUModel
    {
        [Key]
        public int SKPLUID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int ModifyBy { get; set; }
        public bool Status { get; set; }
        public int SocketType { get; set; }
        public string Address { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Interval { get; set; }
        public string MapLocation { get; set; }
    }
}
