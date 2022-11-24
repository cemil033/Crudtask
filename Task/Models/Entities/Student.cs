using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Task.Models.ViewModels;

namespace Task.Models.Entities
{
    [ModelMetadataType(typeof(AddStudentViewModel))]
    public class Student : Entity 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
