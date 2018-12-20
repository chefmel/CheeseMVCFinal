using CheeseMVC2.Data;
using System.Collections.Generic;
using System.Linq;
using CheeseMVC2.Models;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC2.ViewModels;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: /<controller>/
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel =
                new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {

                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = addCategoryViewModel.Name

                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }
    }
}



