namespace IssueTrackingSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Data.Category;
    using IssueTrackingSystem.Services.Data.Ticket;
    using IssueTrackingSystem.Web.ViewModels.Categories;
    using IssueTrackingSystem.Web.ViewModels.Tickets;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class TicketsController : Controller
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

        public IActionResult Create()
        {
            var viewModel = new CreateTicketInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.ticketsService.CreateAsync(input.Title, input.Content, input.CategoryId, input.TicketStatus, input.TicketPriority);

            return this.Redirect("/");
        }
    }
}
