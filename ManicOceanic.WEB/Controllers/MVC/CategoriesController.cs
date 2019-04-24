using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManicOceanic.DOMAIN.Data;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.WEB.Dto;

namespace ManicOceanic.WEB.Controllers.MVC
{
    public class CategoriesController : Controller
    {
        private readonly MOContext _context;

        public CategoriesController(MOContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Categories.ToListAsync());
            List<CategoryDto> CategoryDtos = new List<CategoryDto>();
            return View(CategoryDtos);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            //if (category == null)
            //{
            //    return NotFound();
            //}
            CategoryDto CategoryDto = new CategoryDto();

            return View(CategoryDto);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Description")] Category category)
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] CategoryDto CategoryDto)
        {
            if (ModelState.IsValid)
            {
                CategoryDto cDto = CategoryDto;

                //_context.Add(category);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(CategoryDto);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryDto CategoryDto = new CategoryDto();
            if (CategoryDto == null)
            {
                return NotFound();
            }
            return View(CategoryDto);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                CategoryDto cDto = categoryDto;
            }
            return View(categoryDto);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
