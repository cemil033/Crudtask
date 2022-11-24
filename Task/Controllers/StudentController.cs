using Task.Data;
using Task.Models.Entities;
using Task.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Text.RegularExpressions;

namespace Lesson9EfCoreCodeFirst.Controllers
{
    public class StudentController : Controller
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;

        public StudentController(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var students = new List<Student>();
            Console.WriteLine("salam");
            foreach (var student in _dbContext.Students.Include("Group"))
            {
                students.Add(new Student()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Surname = student.Surname,
                    Group = student.Group
                });
            }

            return View(students);
        }
        
        public IActionResult Add()
        {
            List<SelectListItem> groups = new();
            foreach (var group in _dbContext.Groups)
            {
                groups.Add(new SelectListItem() { Text = group.Name, Value = group.Id.ToString() });
            }
            ViewData["groups"] = groups;
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = _mapper.Map<Student>(model);
                _dbContext.Add(student);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<SelectListItem> groups = new();
                foreach (var group in _dbContext.Groups)
                {
                    groups.Add(new SelectListItem() { Text = group.Name, Value = group.Id.ToString() });
                }
                ViewData["groups"] = groups;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int sId)
        {
            
            var std= _dbContext.Students.Include("Group").FirstOrDefault(s => s.Id == sId);
            if(std != null)
            {
                _dbContext.Remove(std);
                _dbContext.SaveChanges();
                return Redirect("Index");
            }            
            return View();
        }
        public static int sid { get; set; }
        [HttpGet]
        public IActionResult Update(int sId)
        {
            sid = sId;
            Student student = _dbContext.Students.FirstOrDefault(e => e.Id == sId);
            List<SelectListItem> groups = new();
            foreach (var group in _dbContext.Groups)
            {
                groups.Add(new SelectListItem() { Text = group.Name, Value = group.Id.ToString() });
            }
            ViewData["groups"] = groups;
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(AddStudentViewModel student,int sId)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.FirstOrDefault(e => e.Id == sid).Name = student.Name;
                _dbContext.Students.FirstOrDefault(e => e.Id == sid).Surname = student.Surname;
                _dbContext.Students.FirstOrDefault(e => e.Id == sid).GroupId = student.GroupId;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> groups = new();
            foreach (var group in _dbContext.Groups)
            {
                groups.Add(new SelectListItem() { Text = group.Name, Value = group.Id.ToString() });
            }
            ViewData["groups"] = groups;      
            var student1 = _mapper.Map<Student>(student);
            return View(student1);

        }
    }
}
