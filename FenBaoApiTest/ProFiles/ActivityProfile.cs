using AutoMapper;
using FenBaoApiTest.Dtos;
using FenBaoApiTest.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace FenBaoApiTest.ProFiles
{
    public class ActivityProfile:Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activity, ActivitiesDto>();
            CreateMap<ActivityCreateDto, Activity>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<ActivityUpdateDto, Activity>();
            CreateMap<Activity, ActivityUpdateDto>();
        }
    }
}
