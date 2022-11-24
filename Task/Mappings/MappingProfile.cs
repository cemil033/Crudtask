using AutoMapper;
using Task.Models;
using Task.Models.Entities;
using Task.Models.ViewModels;

namespace Task.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, AddStudentViewModel>();

            CreateMap<Student, AddStudentViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))               
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ReverseMap();
            
            CreateMap<Group, AddGroupViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
