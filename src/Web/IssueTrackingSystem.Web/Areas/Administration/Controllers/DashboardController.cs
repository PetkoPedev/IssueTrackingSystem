namespace IssueTrackingSystem.Web.Areas.Administration.Controllers
{
    using IssueTrackingSystem.Services.Data;
    using IssueTrackingSystem.Services.Data.Counts;
    using IssueTrackingSystem.Services.Data.Dashboard;
    using IssueTrackingSystem.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IGetCountsService getCountsService;
        private readonly IDashboardServices dashboardServices;

        public DashboardController(IGetCountsService getCountsService, IDashboardServices dashboardServices)
        {
            this.getCountsService = getCountsService;
            this.dashboardServices = dashboardServices;
        }

        public IActionResult Index()
        {
            IndexViewModel dashboard = new IndexViewModel();
            dashboard.ArticlesCount = this.dashboardServices.GetArticlesCounts();
            dashboard.NotesCount = this.dashboardServices.GetNotesCounts();
            dashboard.CategoriesCount = this.dashboardServices.GetCategoriesCounts();
            dashboard.TicketsCount = this.dashboardServices.GetTicketsCounts();

            return this.View(dashboard);
            // var viewModel = new IndexViewModel { };
            // return this.View(viewModel);
        }
    }
}
