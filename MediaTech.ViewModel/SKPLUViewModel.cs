using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediaTech.ViewModel
{
    public class SKPLUViewModel
    {
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int ModifyBy { get; set; }
        [DisplayName("SPKLU Status")]
        public bool Status { get; set; }
        [DisplayName("SPKLU Type")]
        public int SocketType { get; set; }
        [DisplayName("SPKLU Address")]
        public string Alamat { get; set; }
        [DisplayName("Map Location")]
        public string MapLocation { get; set; }
        [DisplayName("Operational Time")]
        public int SKPLUID { get; set; }
        [DisplayName("SPKLU Name")]
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Interval { get; set; }
    }
}
