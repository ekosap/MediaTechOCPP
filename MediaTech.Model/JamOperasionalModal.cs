using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediaTech.Model
{
    [Table("JamOperational")]
    public class JamOperasionalModal
    {
        [Key]
        public long JamOperationalID { get; set; }
        public long SKPLUID { get; set; }
        public TimeSpan? StartAt { get; set; }
        public TimeSpan? FinishAt { get; set; }
    }
}
