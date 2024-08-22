using Microsoft.AspNetCore.Mvc;
using OTA_Portal_Service.Models.DTOs;

namespace OTA_Portal_Service.Services.Interfaces
{
    public interface IRepositoryService
    {
        // About Slides
        public Task<ResponseDto> AddSlide(SlidePostDtos slidePostDtos);
        public  Task<List<SlideGetDtos>> GetAllSlides();
        public  Task<List<SlideGetDtos>> GetSlidesById(int id);
        public  Task<ResponseDto> ApproveSlidesById(int id);
        public Task<List<SlideGetDtos>> GetApprovedSlides();
        public  Task<List<SlideGetDtos>> GetApprovedSlidesById(int id);
        public  Task<ResponseDto> UpdateSlides(SlideGetDtos slideGetDtos);
        public  Task<ResponseDto> DeleteSlideById(int id);



        // About Blogs
        public Task<ResponseDto> AddBlogsAndNews(BlogsAndNewsPostDto blogsAndNewsPostDto);
        public Task<List<BlogsAndNewsGetDto>> GetAllBlogsAndNews();
        public Task<List<BlogsAndNewsGetDto>> GetBlogsAndNewsById(int id);
        public Task<ResponseDto> ApproveBlogsAndNewsById(int id);
        public Task<List<BlogsAndNewsGetDto>> GetApprovedBlogsAndNews();
        public Task<List<BlogsAndNewsGetDto>> GetApprovedBlogsAndNewsById(int id);
        public Task<ResponseDto> UpdateBlogsAndNews(UpdateBlogsAndNews blogsAndNewsGetDto);
        public Task<ResponseDto> DeleteBlogsAndNewsById(int id);



        // About Comments
        public  Task<ResponseDto> AddComments(CommentsPostDto commentsPostDto);
        public  Task<List<CommentsGetDto>> GetAllComments();
        public Task<ResponseDto> DeleteCommentsById(int id);



        // About ContactUs
        public  Task<ResponseDto> AddContactUs(contactUsPostDto contactUsPostDto);
        public Task<List<contactUsGetDto>> GetAllContactUs();
        public Task<List<contactUsGetDto>> GetContactById(int id);
        public Task<ResponseDto> DeleteContactById(int id);
      

        
        // About Goals
        public  Task<ResponseDto> AddGoals(goalPostDto goalPostDto);
        public Task<List<goalGetDto>> GetAllGoals();
        public Task<List<goalGetDto>> GetGoalsById(int id);
        public Task<ResponseDto> ApproveGoalsById(int id);
        public Task<List<goalGetDto>> GetApprovedGoals();
        public Task<List<goalGetDto>> GetApprovedGoalsById(int id);
        public Task<ResponseDto> UpdateGoals(goalGetDto goalGetDto);
        public Task<ResponseDto> DeleteGoalsById(int id);






        // About Mission
        public Task<ResponseDto> AddMission(missionPostDto missionPost);
        public Task<List<missionGetDto>> GetAllMission();
        public Task<List<missionGetDto>> GetMissionById(int id);
        public Task<ResponseDto> ApproveMissionById(int id);
        public Task<List<missionGetDto>> GetApprovedMission();
        public Task<List<missionGetDto>> GetApprovedMissionById(int id);
        public Task<ResponseDto> UpdateMission(missionGetDto missionGetDto);
        public Task<ResponseDto> DeleteMissionById(int id);



        // About Ruls
        public Task<ResponseDto> AddRule(RulePostDto rulePostDto);
        public Task<List<RuleGetDto>> GetAllRule();
        public Task<List<RuleGetDto>> GetRuleById(int id);
        public Task<ResponseDto> ApproveRuleById(int id);
        public Task<List<RuleGetDto>> GetApprovedRule();
        public Task<List<RuleGetDto>> GetApprovedRuleById(int id);
        public Task<ResponseDto> UpdateRule(RuleGetDto ruleGetDto);
        public Task<ResponseDto> DeleteRuleById(int id);



        // About Service
        public Task<ResponseDto> AddService(ServicesPostDTOs servicesPostDTOs);
        public Task<List<ServiceGetDTOs>> GetAllService();
        public Task<List<ServiceGetDTOs>> GetServiceById(int id);
        public Task<ResponseDto> ApproveServiceById(int id);
        public Task<List<ServiceGetDTOs>> GetApprovedService();
        public Task<List<ServiceGetDTOs>> GetApprovedServiceById(int id);
        public Task<ResponseDto> UpdateService(ServiceGetDTOs serviceGetDTOs);
        public Task<ResponseDto> DeleteServiceById(int id);



        // About Team
        public Task<ResponseDto> AddTeamMember(TeamMemberPostDTOs teamMemberPostDTOs);
        public Task<List<TeamMemberGetDTOs>> GetAllTeamMember();
        public Task<List<TeamMemberGetDTOs>> GetTeamMemberById(int id);
        public Task<ResponseDto> ApproveTeamMemberById(int id);
        public Task<List<TeamMemberGetDTOs>> GetApprovedTeamMember();
        public Task<List<TeamMemberGetDTOs>> GetApprovedTeamMemberById(int id);
        public Task<ResponseDto> UpdateTeamMember(TeamMemberGetDTOs teamMemberGetDTOs);
        public Task<ResponseDto> DeleteTeamMemberById(int id);



        // About Testimonies
        public Task<ResponseDto> AddTestimonies(testiminiesUpdateDto testiminiesUpdateDto);
        public Task<List<testiminiesGetDto>> GetAllTestimonies();
        public Task<List<testiminiesGetDto>> GetTestimoniesById(int id);
        public Task<ResponseDto> ApproveTestimoniesById(int id);
        public Task<List<testiminiesGetDto>> GetApprovedTestimonies();
        public Task<List<testiminiesGetDto>> GetApprovedTestimoniesById(int id);
        public Task<ResponseDto> UpdateTestimonies(testiminiesGetDto testiminiesGetDto);
        public Task<ResponseDto> DeleteTestimoniesById(int id);



        // About Vision
        public Task<ResponseDto> AddVision(VisionPostDto visionPostDto);
        public Task<List<VisionGetDto>> GetAllVision();
        public Task<List<VisionGetDto>> GetVisionById(int id);
        public Task<ResponseDto> ApproveVisionById(int id);
        public Task<List<VisionGetDto>> GetApprovedVision();
        public Task<List<VisionGetDto>> GetApprovedVisionById(int id);
        public Task<ResponseDto> UpdateVision(VisionGetDto visionGetDto);
        public Task<ResponseDto> DeleteVisionById(int id);



    }
}
