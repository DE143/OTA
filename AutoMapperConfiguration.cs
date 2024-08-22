using AutoMapper;
using OTA_Portal_Service.Models.DTOs;
using OTA_Portal_Service.Models.Entities;

namespace OTA_Portal_Service
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration() {
            CreateMap<Slide, SlideGetDtos>();
            CreateMap<BlogsAndNews, BlogsAndNewsGetDto>();
            CreateMap<Comments, CommentsGetDto>();
            CreateMap<contactUs, contactUsGetDto>();
            CreateMap<goal, goalGetDto>();
            CreateMap<mission, missionGetDto>();
            CreateMap<Rule, RuleGetDto>();
            CreateMap<Service, ServiceGetDTOs>();
            CreateMap<TeamMember, TeamMemberGetDTOs>();
            CreateMap<testimonies, testiminiesGetDto>();
            CreateMap<Vision, VisionGetDto>();
        }
        

    }
}
