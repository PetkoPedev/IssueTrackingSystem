namespace IssueTrackingSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IssueTrackingSystem.Services.Data.Category;
    using IssueTrackingSystem.Services.Data.Ticket;
    using IssueTrackingSystem.Web.ViewModels.Categories;
    using IssueTrackingSystem.Web.ViewModels.Tickets;
    using Microsoft.AspNetCore.Mvc;

    public class TicketsController : Controller
    {
        private readonly ITicketsService ticketsService;
        private readonly ICategoriesService categoriesService;

        public TicketsController(
            ITicketsService ticketsService,
            ICategoriesService categoriesService)
        {
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
            var viewModel = new CreateTicketInputModel
            {
                Title = input.Title,
                Content = input.Content,
                CategoryId = input.CategoryId,
                TicketStatus = input.TicketStatus,
                TicketPriority = input.TicketPriority,
            };

            return this.View(viewModel);
        }
    }
}
