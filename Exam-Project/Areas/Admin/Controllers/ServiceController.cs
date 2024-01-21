using Exam_Project.Areas.Admin.ViewModels.ServiceVM;
using Exam_Project.Context;
using Exam_Project.Helpers;
using Exam_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        BoocicDbContext _context { get; }

        public ServiceController(BoocicDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Services.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServiceCreateItemVM vm)
        {
            Service service = new Service
            {
                Image = await vm.ImageFile.SaveAsync(PathConstants.Product),
                Name = vm.Name
            };
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var item = await _context.Services.FindAsync(id);
            return View(new ServiceUpdateItemVM
            {
                Name = item.Name
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, ServiceUpdateItemVM vm)
        {
            var item = await _context.Services.FindAsync(id);
            item.Image = await vm.ImageFile.SaveAsync(PathConstants.Product);
            item.Name = vm.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Services.FindAsync(id);
            _context.Services.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
