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
        public string Alamat { get; set; }
        [DisplayName("Map Location")]
        public string MapLocation { get; set; }
        
        public int SKPLUID { get; set; }
        [DisplayName("SPKLU Name")]
        [Required]
        public string Name { get; set; }
        [DisplayName("SPKLU Address")]
        [Required]
        public string Address { get; set; }
        [DisplayName("Open Operational Time")]
        [Required]
        public TimeSpan StartTime { get; set; }
        [DisplayName("Close Operational Time")]
        [Required]
        public TimeSpan EndTime { get; set; }
        [DisplayName("Interval Operational Time")]
        [Required][Range(1,60, ErrorMessage ="Data must in range 1 to 60")]
        public int Interval { get; set; }
    }
}
