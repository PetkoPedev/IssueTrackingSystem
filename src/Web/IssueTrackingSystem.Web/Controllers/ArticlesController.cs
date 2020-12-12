namespace IssueTrackingSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Data.Articles;
    using IssueTrackingSystem.Services.Data.Categories;
    using IssueTrackingSystem.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ArticlesController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IArticlesService articlesService;
        private readonly ICategoriesService categoriesService;

        public ArticlesController(
            UserManager<ApplicationUser> userManager,
            IArticlesService articlesService,
            ICategoriesService categoriesService)
        {
            this.userManager = userManager;
            this.articlesService = articlesService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateArticleInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            var user = this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var article = await this.articlesService.CreateAsync(input.ArticleName, input.Content, input.UserId, input.CategoryId);
            return this.View("/");
        }

        [Authorize]
        public IActionResult GetAll(int id = 1)
        {
            return this.View();
        }
    }
}
