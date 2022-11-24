using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Task.Models.ViewModels
{
    public class AddStudentViewModel
    {
        
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]        
        public string Name { get; set; }

        
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Group is required")]       
        public int GroupId { get; set; }
    }
}
