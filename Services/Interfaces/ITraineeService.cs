using Microsoft.AspNetCore.Mvc;
using OTA_Portal_Service.Models.DTOs;

namespace OTA_Portal_Service.Services.Interfaces
{
    public interface ITraineeService
    {
        public  Task<ResponseDto> AddTrainee(PersonalProfilePostDTO personalProfilePostDTO);
        //public  Task<ResponseDto> AddTraineeAddress(PersonalAddressPostDTO personalAddressPostDTO);
   
    }
}
