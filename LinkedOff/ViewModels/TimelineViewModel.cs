using LinkedOff.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedOff.ViewModels
{
    public class TimelineViewModel
    {
        public int TimelineId { get; set; }
        public LinkedUser User { get; set; }
        public string StatusMessage { get; set; }

        public ICollection<StatusUpdate> StatusUpdates { get; set; }


    }
}
