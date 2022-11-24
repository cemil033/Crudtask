using Task.Data;
using Task.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Task.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Task.Controllers
{
    public class GroupController : Controller
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;

        public GroupController(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper=mapper; 
        }

        public IActionResult Index()
        {
            var groups = _dbContext.Groups.ToList();
            return View(groups);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var group1=_mapper.Map<Group>(model);
                _dbContext.Add(group1);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Delete(int sId)
        {

            var grp = _dbContext.Groups.FirstOrDefault(s => s.Id == sId);
            if (grp != null)
            {
                _dbContext.Remove(grp);
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
            Group group = _dbContext.Groups.FirstOrDefault(e => e.Id == sId);   
            return View(group);
        }

        [HttpPost]
        public IActionResult Update(AddGroupViewModel group, int sId)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Groups.FirstOrDefault(e => e.Id == sid).Name = group.Name; 
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }            
            var group1 = _mapper.Map<Group>(group);
            return View(group1);

        }
    }
}
