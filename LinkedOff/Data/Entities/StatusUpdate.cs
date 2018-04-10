using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedOff.Data.Entities
{
    public class StatusUpdate
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public LinkedUser User { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
