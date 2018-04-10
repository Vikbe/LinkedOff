using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedOff.Data.Entities
{
    public class Timeline
    {
        public int Id { get; set; }
        public LinkedUser User { get; set; }
        public string StatusMessage { get; set; }

        public ICollection<StatusUpdate> StatusUpdates { get; set; }
    }
}
