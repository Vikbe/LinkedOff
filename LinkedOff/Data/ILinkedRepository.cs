using System.Collections.Generic;
using LinkedOff.Data.Entities;

namespace LinkedOff.Data
{
    public interface ILinkedRepository
    {
        IEnumerable<Experience> GetExperience();
        IEnumerable<Timeline> GetTimeLine();
        IEnumerable<StatusUpdate> GetTimelineByUser(string username);
        bool SaveAll();
        void AddEntity(object model);
        StatusUpdate GetStatusById(string name, int statusId);
        Timeline GetTimelineById(string name, int timelineId);
    }
}