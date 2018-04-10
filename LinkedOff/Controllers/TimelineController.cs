using AutoMapper;
using LinkedOff.Data;
using LinkedOff.Data.Entities;
using LinkedOff.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkedOff.Controllers
{
    [Route("[Controller]/[Action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TimelineController : Controller
    {
        private readonly ILinkedRepository _repo;
        private readonly ILogger<TimelineController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<LinkedUser> _userManager;

        public TimelineController(ILinkedRepository repo, ILogger<TimelineController> logger, 
            IMapper mapper, UserManager<LinkedUser> userManager)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var username = User.Identity.Name;

                var results = _repo.GetTimelineByUser(username);

                return Ok(_mapper.Map<IEnumerable<StatusUpdate>, IEnumerable<StatusUpdateViewModel>>(results));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve timeline: {ex}");
                return BadRequest("Failed to get timeline");
              
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StatusUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newStatus = _mapper.Map<StatusUpdateViewModel, StatusUpdate>(model); 

                    if (newStatus.DatePosted == DateTime.MinValue)
                    {
                        newStatus.DatePosted = DateTime.Now;
                    }

                    var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

                    newStatus.User = currentUser;

                    _repo.AddEntity(newStatus); 

                    if (_repo.SaveAll())
                    {
                        return Created($"/app/timeline/{User.Identity.Name}", _mapper.Map<StatusUpdate, StatusUpdateViewModel>(newStatus));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to send status update: {ex}");
                
            }

            return BadRequest("Failed to send");
        }

    }
}
