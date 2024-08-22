using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTA_Portal_Service.Migrations;
using OTA_Portal_Service.Models.DTOs;
using OTA_Portal_Service.Services.Interfaces;

namespace OTA_Portal_Service.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRepositoryService _repository;
        public HomeController(IRepositoryService repository) 
        { 
            _repository = repository;
        }


        // About Slide
        [HttpPost]
        public async Task<ActionResult> AddSlide( [FromForm] SlidePostDtos slidePostDtos)
        {
            var addSlide= await _repository.AddSlide(slidePostDtos);
            return Ok(addSlide);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSlides()
        {
            var getallSlides = await _repository.GetAllSlides();
            return Ok(getallSlides);
        }

       
        
        [HttpGet]
        public async Task<ActionResult> GetSlidesById(int id)
        {
            var getSlideById = await _repository.GetSlidesById(id);
            return Ok(getSlideById);
        }
       
        
        [HttpPut]
        public async Task<ActionResult> ApproveSlidesById(int id)
        {
            var approveSlide = await _repository.ApproveSlidesById(id);
            return Ok(approveSlide);
        }
       
        
        [HttpGet]
        public async Task<ActionResult> GetApprovedSlides()
        {
            var getApprovedSlide = await _repository.GetApprovedSlides();
            return Ok(getApprovedSlide);
        }
       
        
        [HttpGet]
        public async Task<ActionResult> GetApprovedSlidesById(int id)
        {
            var getApprovedSlideById = await _repository.GetApprovedSlidesById(id);
            return Ok(getApprovedSlideById);
        }
       
        
        [HttpPut]
        public async Task<ActionResult> UpdateSlides(SlideGetDtos slideGetDtos)
        {
            var Slides = await _repository.UpdateSlides(slideGetDtos);
            return Ok(Slides);
        }
       
        
        [HttpDelete]
        public async Task<ActionResult> DeleteSlideById(int id)
        {
            var deleteSlide = await _repository.DeleteSlideById(id);
            return Ok(deleteSlide);
        }
       
        
        
        
        // About Blogs
        [HttpPost]
        public async Task<ActionResult> AddBlogsAndNews([FromForm] BlogsAndNewsPostDto blogsAndNewsPostDto)
        {
            var addBlogs = await _repository.AddBlogsAndNews(blogsAndNewsPostDto);
            return Ok(addBlogs);
        }
      
        
        [HttpGet]
        public async Task<ActionResult> GetAllBlogs()
        {
            var getallBlogs = await _repository.GetAllBlogsAndNews();
            return Ok(getallBlogs);
        }

       
        
        [HttpGet]
        public async Task<ActionResult> GetBlogsAndNewsById(int id)
        {
            var getBlogById = await _repository.GetBlogsAndNewsById(id);
            return Ok(getBlogById);
        }
       
        
        [HttpPut]
        public async Task<ActionResult> ApproveBlogsAndNewsById(int id)
        {
            var approveBlog = await _repository.ApproveBlogsAndNewsById(id);
            return Ok(approveBlog);
        }
       
        
        [HttpGet]
        public async Task<ActionResult> GetApprovedBlogsAndNews()
        {
            var getApprovedBlog = await _repository.GetApprovedBlogsAndNews();
            return Ok(getApprovedBlog);
        }
       
        
        [HttpGet]
        public async Task<ActionResult> GetApprovedBlogsAndNewsById(int id)
        {
            var getApprovedBlogById = await _repository.GetApprovedBlogsAndNewsById(id);
            return Ok(getApprovedBlogById);
        }


        //[HttpPut]
        //public async Task<ActionResult> UpdateBlogsAndNews([FromForm] BlogsAndNewsGetDto blogsAndNewsGetDto)
        //{
        //    var blogs = await _repository.UpdateBlogsAndNews(blogsAndNewsGetDto);
        //    return Ok(blogs);
        //}

        [HttpPut]
        public async Task<ActionResult> UpdateBlogsAndNew([FromForm] UpdateBlogsAndNews blogsAndNewsGetDto)
        {
            var updateBlog = await _repository.UpdateBlogsAndNews(blogsAndNewsGetDto);
            return Ok(updateBlog);
        }
       
        
        [HttpDelete]
        public async Task<ActionResult> DeleteBlogsAndNewsById(int id)
        {
            var deleteSlide = await _repository.DeleteBlogsAndNewsById(id);
            return Ok(deleteSlide);
        }




        // About Comments
        [HttpPost]
        public async Task<ActionResult> AddComments([FromForm] CommentsPostDto commentsPostDto)
        {
            var addComment = await _repository.AddComments(commentsPostDto);
            return Ok(addComment);
        }
       
        
        [HttpGet]
        public async Task<ActionResult> GetAllComments()
        {
            var getallComments = await _repository.GetAllComments();
            return Ok(getallComments);
        }           
       
        
        [HttpDelete]
        public async Task<ActionResult> DeleteCommentsById(int id)
        {
            var deleteSlide = await _repository.DeleteCommentsById(id);
            return Ok(deleteSlide);
        }



        // About ContactUs
       
        
        [HttpPost]
        public async Task<ActionResult> AddContactUs(contactUsPostDto contactUsPostDto)
        {
            var addContact = await _repository.AddContactUs(contactUsPostDto);
            return Ok(addContact);
        }
       
        
        [HttpGet]
        public async Task<ActionResult> GetAllContactUs()
        {
            var getallBlogs = await _repository.GetAllContactUs();
            return Ok(getallBlogs);
        }

       
        
        [HttpGet]
        public async Task<ActionResult> GetContactUsById(int id)
        {
            var getById = await _repository.GetContactById(id);
            return Ok(getById);
        }
        
       
        
        [HttpDelete]
        public async Task<ActionResult> DeleteContactUsById(int id)
        {
            var deleteContact = await _repository.DeleteContactById(id);
            return Ok(deleteContact);
        }






        // About Goals
        [HttpPost]
        public async Task<ActionResult> AddGoals(goalPostDto goalPostDto)
        {
            var addGoals = await _repository.AddGoals(goalPostDto);
            return Ok(addGoals);
        }
      
        
        [HttpGet]
        public async Task<ActionResult> GetAllGoals()
        {
            var getall = await _repository.GetAllGoals();
            return Ok(getall);
        }

       
        
        [HttpGet]
        public async Task<ActionResult> GetGoalsById(int id)
        {
            var getById = await _repository.GetGoalsById(id);
            return Ok(getById);
        }
       
        
        
        [HttpPut]
        public async Task<ActionResult> ApproveGoalsById(int id)
        {
            var approve = await _repository.ApproveGoalsById(id);
            return Ok(approve);
        }
       
        
        [HttpGet]
        public async Task<ActionResult> GetApprovedGoals()
        {
            var getApprovedGoal = await _repository.GetApprovedGoals();
            return Ok(getApprovedGoal);
        }
      
        
        [HttpGet]     
         public async Task<ActionResult> GetApprovedGoalsById(int id)
        {
            var getApprovedGoalsById = await _repository.GetApprovedGoalsById(id);
            return Ok(getApprovedGoalsById);
        }
   
        
        [HttpPut]
        public async Task<ActionResult> UpdateBlogsAndNews(goalGetDto goalGetDto)
        {
            var updateGoal = await _repository.UpdateGoals(goalGetDto);
            return Ok(updateGoal);
        }
       
        
        [HttpDelete]
        public async Task<ActionResult> DeleteGoalById(int id)
        {
            var deleteGoals = await _repository.DeleteGoalsById(id);
            return Ok(deleteGoals);
        }


        // About Mission

        [HttpPost]
        public async Task<ActionResult> AddMission(missionPostDto missionPost)
        {
            var addMission = await _repository.AddMission(missionPost);
            return Ok(addMission);
        }
       
        
        [HttpGet]
        public async Task<ActionResult> GetAllMission()
        {
            var getall = await _repository.GetAllMission();
            return Ok(getall);
        }

       
        [HttpGet]
        public async Task<ActionResult> GetMissionById(int id)
        {
            var getId = await _repository.GetMissionById(id);
            return Ok(getId);
        }
      
        
        [HttpPut]
        public async Task<ActionResult> ApproveMissionById(int id)
        {
            var approve = await _repository.ApproveMissionById(id);
            return Ok(approve);
        }
      
        
        [HttpGet]
        public async Task<ActionResult> GetApprovedMission()
        {
            var getApprovedMission = await _repository.GetApprovedMission();
            return Ok(getApprovedMission);
        }
      
        
        [HttpGet]
        public async Task<ActionResult> GetApprovedMissionById(int id)
        {
            var getApprovedMissionById = await _repository.GetApprovedMissionById(id);
            return Ok(getApprovedMissionById);
        }
       
        
        [HttpPut]
        public async Task<ActionResult> UpdateMission(missionGetDto missionGetDto)
        {
            var mission = await _repository.UpdateMission(missionGetDto);
            return Ok(mission);
        }
       
        
        [HttpDelete]
        public async Task<ActionResult> DeleteMissionById(int id)
        {
            var deleteMission = await _repository.DeleteMissionById(id);
            return Ok(deleteMission);
        }


        // About Rules
        [HttpPost]
        public async Task<ActionResult> AddRule(RulePostDto rulePostDto)
        {
            var addRules = await _repository.AddRule(rulePostDto);
            return Ok(addRules);
        }
       
        
        
        [HttpGet]
        public async Task<ActionResult> GetAllRules()
        {
            var getallRule = await _repository.GetAllRule();
            return Ok(getallRule);
        }

       
        
        [HttpGet]
        public async Task<ActionResult> GetRulById(int id)
        {
            var getRulById = await _repository.GetRuleById(id);
            return Ok(getRulById);
        }
       
        
        [HttpPut]
        public async Task<ActionResult> ApproveRuleById(int id)
        {
            var approveRule = await _repository.ApproveRuleById(id);
            return Ok(approveRule);
        }
       
        
        [HttpGet]
        public async Task<ActionResult> GetApprovedRule()
        {
            var getApprovedRule = await _repository.GetApprovedRule();
            return Ok(getApprovedRule);
        }
       
        
        [HttpGet]
        public async Task<ActionResult> GetApprovedRuleById(int id)
        {
            var getApprovedRuleById = await _repository.GetApprovedRuleById(id);
            return Ok(getApprovedRuleById);
        }
       
        
        [HttpPut]
        public async Task<ActionResult> UpdateRules(RuleGetDto ruleGetDto)
        {
            var rules = await _repository.UpdateRule(ruleGetDto);
            return Ok(rules);
        }
       
        
        [HttpDelete]
        public async Task<ActionResult> DeleteRuleById(int id)
        {
            var deleteRule = await _repository.DeleteRuleById(id);
            return Ok(deleteRule);
        }





        // About Service
        [HttpPost]
        public async Task<ActionResult> AddService([FromForm] ServicesPostDTOs servicesPostDTOs)
        {
            var addServices = await _repository.AddService(servicesPostDTOs);
            return Ok(addServices);
        }


        [HttpGet]
        public async Task<ActionResult> GetAllService()
        {
            var getall = await _repository.GetAllService();
            return Ok(getall);
        }



        [HttpGet]
        public async Task<ActionResult> GetServiceById(int id)
        {
            var getServiceById = await _repository.GetServiceById(id);
            return Ok(getServiceById);
        }


        [HttpPut]
        public async Task<ActionResult> ApproveServiceById(int id)
        {
            var approve = await _repository.ApproveServiceById(id);
            return Ok(approve);
        }


        [HttpGet]
        public async Task<ActionResult> GetApprovedService()
        {
            var getApprovedService = await _repository.GetApprovedService();
            return Ok(getApprovedService);
        }


        [HttpGet]
        public async Task<ActionResult> GetApprovedServiceById(int id)
        {
            var getApprovedServiceById = await _repository.GetApprovedServiceById(id);
            return Ok(getApprovedServiceById);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateService([FromForm] ServiceGetDTOs serviceGetDTOs)
        {
            var service = await _repository.UpdateService(serviceGetDTOs);
            return Ok(service);
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteServiceById(int id)
        {
            var deleteService = await _repository.DeleteServiceById(id);
            return Ok(deleteService);
        }




        // About TeamMember
        [HttpPost]
        public async Task<ActionResult> AddTeamMember([FromForm] TeamMemberPostDTOs teamMemberPostDTOs)
        {
            var addTeam = await _repository.AddTeamMember(teamMemberPostDTOs);
            return Ok(addTeam);
        }


        [HttpGet]
        public async Task<ActionResult> GetAllTeamMember()
        {
            var getall = await _repository.GetAllTeamMember();
            return Ok(getall);
        }



        [HttpGet]
        public async Task<ActionResult> GetTeamMemberById(int id)
        {
            var getTeamById = await _repository.GetTeamMemberById(id);
            return Ok(getTeamById);
        }



        [HttpPut]
        public async Task<ActionResult> ApproveTeamMemberById(int id)
        {
            var approve = await _repository.ApproveTeamMemberById(id);
            return Ok(approve);
        }



        [HttpGet]
        public async Task<ActionResult> GetApprovedTeamMember()
        {
            var getApprovedTeamMember = await _repository.GetApprovedTeamMember();
            return Ok(getApprovedTeamMember);
        }



        [HttpGet]
        public async Task<ActionResult> GetApprovedTeamMemberById(int id)
        {
            var getApprovedTeamMemberById = await _repository.GetApprovedTeamMemberById(id);
            return Ok(getApprovedTeamMemberById);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateTeamMember([FromForm] TeamMemberGetDTOs teamMemberGetDTOs)
        {
            var teamMember = await _repository.UpdateTeamMember(teamMemberGetDTOs);
            return Ok(teamMember);
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteTeamMemberById(int id)
        {
            var deleteTeamMember = await _repository.DeleteTeamMemberById(id);
            return Ok(deleteTeamMember);
        }



        // About Testimonies
        [HttpPost]
        public async Task<ActionResult> AddTestimonies([FromForm] testiminiesUpdateDto testiminiesUpdateDto)
        {
            var addTestimonies = await _repository.AddTestimonies(testiminiesUpdateDto);
            return Ok(addTestimonies);
        }


        [HttpGet]
        public async Task<ActionResult> GetAllTestimonies()
        {
            var getallTestimonies = await _repository.GetAllTestimonies();
            return Ok(getallTestimonies);
        }



        [HttpGet]
        public async Task<ActionResult> GetTestimonyById(int id)
        {
            var getTestimonyById = await _repository.GetTestimoniesById(id);
            return Ok(getTestimonyById);
        }


        [HttpPut]
        public async Task<ActionResult> ApproveTestimonyById(int id)
        {
            var approveTestimony = await _repository.ApproveTestimoniesById(id);
            return Ok(approveTestimony);
        }


        [HttpGet]
        public async Task<ActionResult> GetApprovedTestimonies()
        {
            var getApprovedTestimony = await _repository.GetApprovedTestimonies();
            return Ok(getApprovedTestimony);
        }


        [HttpGet]
        public async Task<ActionResult> GetApprovedTestimoniesById(int id)
        {
            var getApprovedTestimoniesById = await _repository.GetApprovedTestimoniesById(id);
            return Ok(getApprovedTestimoniesById);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateTestimonies([FromForm] testiminiesGetDto testiminiesGetDto)
        {
            var testimonies = await _repository.UpdateTestimonies(testiminiesGetDto);
            return Ok(testimonies);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTestimoniesById(int id)
        {
            var deleteTestimonies = await _repository.DeleteTestimoniesById(id);
            return Ok(deleteTestimonies);
        }


        // About Vision
        [HttpPost]
        public async Task<ActionResult> AddVision(VisionPostDto visionPostDto)
        {
            var addVision = await _repository.AddVision(visionPostDto);
            return Ok(addVision);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllVision()
        {
            var getall = await _repository.GetAllVision();
            return Ok(getall);
        }


        [HttpGet]
        public async Task<ActionResult> GetVisionById(int id)
        {
            var getVisionById = await _repository.GetVisionById(id);
            return Ok(getVisionById);
        }


        [HttpPut]
        public async Task<ActionResult> ApproveVisionById(int id)
        {
            var approveVision = await _repository.ApproveVisionById(id);
            return Ok(approveVision);
        }


        [HttpGet]
        public async Task<ActionResult> GetApprovedVision()
        {
            var getApprovedVision = await _repository.GetApprovedVision();
            return Ok(getApprovedVision);
        }


        [HttpGet]
        public async Task<ActionResult> GetApprovedVisionById(int id)
        {
            var getApprovedVisionById = await _repository.GetApprovedVisionById(id);
            return Ok(getApprovedVisionById);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateVision(VisionGetDto visionGetDto)
        {
            var vision = await _repository.UpdateVision(visionGetDto);
            return Ok(vision);
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteVisionById(int id)
        {
            var deleteVision = await _repository.DeleteVisionById(id);
            return Ok(deleteVision);
        }

    }
}
