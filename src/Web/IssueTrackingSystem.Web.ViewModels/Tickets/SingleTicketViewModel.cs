namespace IssueTrackingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Ganss.XSS;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;

    public class SingleTicketViewModel : IMapFrom<Ticket>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public string UserUserName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryCategoryName { get; set; }

        public IEnumerable<TicketCommentViewModel> Comments { get; set; }
    }
}
