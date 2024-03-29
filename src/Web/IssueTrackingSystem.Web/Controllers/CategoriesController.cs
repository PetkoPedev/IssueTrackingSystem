﻿namespace IssueTrackingSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Data.Categories;
    using IssueTrackingSystem.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public CategoriesController(
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager)
        {
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult ByName(string name)
        {
            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 4;
            var viewModel = new AllCategoriesViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ItemsCount = this.categoriesService.GetCount(),
                Categories = this.categoriesService.GetAll(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateCategoryInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCategoryInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var viewModel = await this.categoriesService.CreateAsync(input.Name);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
