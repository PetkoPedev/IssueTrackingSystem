namespace IssueTrackingSystem.Web.ViewModels.Tickets
{
    using IssueTrackingSystem.Data.Common.Enums;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class TicketInListViewModel : IMapFrom<Ticket>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Content { get; set; }
    }
}
