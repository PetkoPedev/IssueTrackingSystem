namespace IssueTrackingSystem.Web.ViewModels.Categories
{
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;

    public class TicketCategoryViewModel : IMapFrom<Ticket>
    {
        public string Title { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}