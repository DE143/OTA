﻿namespace OTA_Portal_Service.Models.DTOs
{
    public class VisionPostDto
    {
        public DateTime date { get; set; }
        public string Description { get; set; }
        public string localDescription { get; set; }
        public string? status { get; set; }
    }
    public class VisionGetDto
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string Description { get; set; }
        public string localDescription { get; set; }
        public string? status { get; set; }
    }
}
