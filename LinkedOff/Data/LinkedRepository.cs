using LinkedOff.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedOff.Data
{
    public class LinkedRepository : ILinkedRepository
    {
        private readonly LinkedContext _ctx;
        private readonly ILogger<LinkedRepository> _logger;

        public LinkedRepository(LinkedContext context, ILogger<LinkedRepository> logger)
        {
            _ctx = context;
            _logger = logger;
        }
        
        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Experience> GetExperience()
        {
            return _ctx.Experiences
                 .OrderBy(e => e.StartDate)
                 .ToList();
        }

        public StatusUpdate GetStatusById(string name, int statusId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Timeline> GetTimeLine()
        {
            throw new NotImplementedException();
        }

        //public StatusUpdate GetStatusById(string name, int statusId)
        //{
        //    return _ctx.
        //}



        //public IEnumerable<Timeline> GetTimelineById(int timelineId)
        //{
        //    return _ctx.StatusUpdates
        //        .ToList();
                
        //}

        public Timeline GetTimelineById(string name, int timelineId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatusUpdate> GetTimelineByUser(string username)
        {
            return _ctx.StatusUpdates
                .ToList();
                    
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

      
    }
}
