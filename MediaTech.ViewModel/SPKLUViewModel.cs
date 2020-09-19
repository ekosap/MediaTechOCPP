using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MediaTech.ViewModel
{
    public class SPKLUViewModel
    {
        public int SPKLUId { get; set; }
        [DisplayName("SPKLU Name")]
        public string SPKLUName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int ModifyBy { get; set; }
        [DisplayName("SPKLU Status")]
        public bool Status { get; set; }
        [DisplayName("SPKLU Type")]
        public bool IsACType { get; set; }
        [DisplayName("SPKLU Address")]
        public string Alamat { get; set; }
    }
}
