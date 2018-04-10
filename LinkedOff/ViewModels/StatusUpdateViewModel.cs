using LinkedOff.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedOff.ViewModels
{
    public class StatusUpdateViewModel
    {
        public int StatusUpdateId { get; set; }
        public string Message { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
