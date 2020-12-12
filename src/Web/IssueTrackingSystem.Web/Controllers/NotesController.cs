namespace IssueTrackingSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Data.Notes;
    using IssueTrackingSystem.Web.ViewModels.Notes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class NotesController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INotesService notesService;

        public NotesController(
            UserManager<ApplicationUser> userManager,
            INotesService notesService)
        {
            this.userManager = userManager;
            this.notesService = notesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateNoteInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateNoteInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var note = await this.notesService.CreateAsync(input.Name, input.Content, user.Id);
            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 6;
            var viewModel = new NotesListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ItemsCount = this.notesService.GetCount(),
                Notes = this.notesService.GetAll(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult ById(int id)
        {
            var note = this.notesService.GetById<SingleNoteViewModel>(id);
            return this.View(note);
        }
    }
}
