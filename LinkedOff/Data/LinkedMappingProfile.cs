using AutoMapper;
using LinkedOff.Data.Entities;
using LinkedOff.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedOff.Data
{
    public class LinkedMappingProfile : Profile
    {
        public LinkedMappingProfile()
        {
            CreateMap<Timeline, TimelineViewModel>()
                .ReverseMap();

            CreateMap<StatusUpdate, StatusUpdateViewModel>()
               .ReverseMap();
        }

    }
}
