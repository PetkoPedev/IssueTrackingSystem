namespace IssueTrackingSystem.Web.Areas.Administration.Controllers
{
    using IssueTrackingSystem.Services.Data;
    using IssueTrackingSystem.Services.Data.Counts;
    using IssueTrackingSystem.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IGetCountsService getCountsService;

        public DashboardController(IGetCountsService getCountsService)
        {
            this.getCountsService = getCountsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { };
            return this.View(viewModel);
        }
    }
}
