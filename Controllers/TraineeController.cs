using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTA_Portal_Service.Models.DTOs;
using OTA_Portal_Service.Services.Interfaces;

namespace OTA_Portal_Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private readonly ITraineeService _trainee;
        public TraineeController(ITraineeService trainee)
        {
            _trainee = trainee;   
        }


        [HttpPost]
        public async Task<ActionResult> AddTrainee(PersonalProfilePostDTO personalProfilePostDTO)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _trainee.AddTrainee(personalProfilePostDTO));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


      //  [HttpPost]
        //public async Task<ActionResult> AddTraineeAddress(PersonalAddressPostDTO personalAddressPostDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return Ok(await _trainee.AddTraineeAddress(personalAddressPostDTO));
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

     
    } 
}
