using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTech.ViewModel
{
    public class JamOperationalViewModel
    {
        public long JamOperationalID { get; set; }
        public long SKPLUID { get; set; }
        public TimeSpan? StartAt { get; set; }
        public TimeSpan? FinishAt { get; set; }
    }
}
