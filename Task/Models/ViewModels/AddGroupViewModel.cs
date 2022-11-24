using System.ComponentModel.DataAnnotations;

namespace Task.Models.ViewModels
{
    public class AddGroupViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
