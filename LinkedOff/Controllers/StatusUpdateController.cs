using AutoMapper;
using LinkedOff.Data;
using LinkedOff.Data.Entities;
using LinkedOff.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LinkedOff.Controllers
{
    [Route("/api/timeline/{timelineid}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StatusUpdateController : Controller
    {
        private readonly ILinkedRepository _repo;
        private readonly ILogger<StatusUpdateController> _logger;
        private readonly IMapper _mapper;

        public StatusUpdateController(ILinkedRepository repo,
          ILogger<StatusUpdateController> logger,
          IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int timelineId)
        {
            var timeline = _repo.GetTimelineById(User.Identity.Name, timelineId);
            if (timeline != null) return Ok(_mapper.Map<IEnumerable<StatusUpdate>, IEnumerable<StatusUpdateViewModel>>(timeline.StatusUpdates));
            return NotFound();
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(int timelineId, int id)
        //{
        //    var timeline = _repo.GetTimelineById(User.Identity.Name, timelineId);
        //    if (timeline != null)
        //    {
        //        var status = 
        //        if (status != null)
        //        {
        //            return Ok(_mapper.Map<StatusUpdate, StatusUpdateViewModel>(status));
        //        }
        //    }
        //    return NotFound();

        //}


    }
}
