namespace IssueTrackingSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Data.Categories;
    using IssueTrackingSystem.Services.Data.Ticket;
    using IssueTrackingSystem.Web.ViewModels.Categories;
    using IssueTrackingSystem.Web.ViewModels.Tickets;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class TicketsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITicketsService ticketsService;
        private readonly ICategoriesService categoriesService;

        public TicketsController(
            UserManager<ApplicationUser> userManager,
            ITicketsService ticketsService,
            ICategoriesService categoriesService)
        {
            this.userManager = userManager;
            this.ticketsService = ticketsService;
            this.categoriesService = categoriesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateTicketInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTicketInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var ticketId = await this.ticketsService.CreateAsync(input.Title, input.Content, input.CategoryId, user.Id, input.TicketStatus, input.TicketPriority);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 4;
            var viewModel = new TicketsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ItemsCount = this.ticketsService.GetCount(),
                Tickets = this.ticketsService.GetAll(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult ById(int id)
        {
            var ticket = this.ticketsService.GetById<SingleTicketViewModel>(id);
            return this.View(ticket);
        }
    }
}
