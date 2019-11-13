using AutoMapper;
using LangateTaskTracker.DAL.Entities;
using LangateTaskTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LangateTaskTracker.Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TrackerTask, TrackerTaskModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.TaskStatus))
                .ReverseMap().ConstructUsing((source, context) => new TrackerTask());
        }
    }
}
