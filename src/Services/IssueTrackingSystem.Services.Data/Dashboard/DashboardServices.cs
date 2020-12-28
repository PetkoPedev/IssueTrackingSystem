namespace IssueTrackingSystem.Services.Data.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Services.Data.Articles;
    using IssueTrackingSystem.Services.Data.Categories;
    using IssueTrackingSystem.Services.Data.Notes;
    using IssueTrackingSystem.Services.Data.Ticket;

    public class DashboardServices : IDashboardServices
    {
        private readonly IArticlesService articlesService;
        private readonly ICategoriesService categoriesService;
        private readonly INotesService notesService;
        private readonly ITicketsService ticketsService;

        public DashboardServices(
            IArticlesService articlesService,
            ICategoriesService categoriesService,
            INotesService notesService,
            ITicketsService ticketsService)
        {
            this.articlesService = articlesService;
            this.categoriesService = categoriesService;
            this.notesService = notesService;
            this.ticketsService = ticketsService;
        }

        public int GetArticlesCounts()
        {
            return this.articlesService.GetCount();
        }

        public int GetCategoriesCounts()
        {
            return this.categoriesService.GetCount();
        }

        public int GetNotesCounts()
        {
            return this.notesService.GetCount();
        }

        public int GetTicketsCounts()
        {
            return this.ticketsService.GetCount();
        }
    }
}
