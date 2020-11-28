namespace IssueTrackingSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IssueTrackingSystem.Services.Data.Category;
    using IssueTrackingSystem.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult ByName(string name)
        {
            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);
            return this.View(viewModel);
        }

        public IActionResult GetAll()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult GetAll(int id)
        {
            var viewModel = this.categoriesService.GetAll<AllCategoriesViewModel>(id);
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            var viewModel = this.categoriesService.CreateAsync(name);
            return this.View(viewModel);
        }
    }
}
