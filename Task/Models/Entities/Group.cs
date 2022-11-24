using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Task.Models.ViewModels;

namespace Task.Models.Entities
{
    [ModelMetadataType(typeof(AddGroupViewModel))]
    public class Group : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}