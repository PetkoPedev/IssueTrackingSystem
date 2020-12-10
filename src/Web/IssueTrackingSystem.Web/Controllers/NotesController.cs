namespace IssueTrackingSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IssueTrackingSystem.Services.Data.Notes;
    using Microsoft.AspNetCore.Mvc;

    public class NotesController : BaseController
    {
        private readonly INotesService notesService;

        public NotesController(INotesService notesService)
        {
            this.notesService = notesService;
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
