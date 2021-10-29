using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Models.DTO
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseCode { get; set; }
        [Required]
        public string Technology { get; set; }
    }

}
