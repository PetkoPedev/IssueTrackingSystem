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

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateArticleInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllCategoriesAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllCategoriesAsKeyValuePairs();
                return this.View(input);
            }

            var article = await this.articlesService.CreateAsync(input.ArticleName, input.Content, input.CategoryId, user.Id);
            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 4;
            var viewModel = new ArticlesListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ItemsCount = this.articlesService.GetCount(),
                Articles = this.articlesService.GetAll(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult ById(int id)
        {
            var article = this.articlesService.GetById<SingleArticleViewModel>(id);
            return this.View(article);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.articlesService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
