namespace IssueTrackingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    // using IssueTrackingSystem.Data.Common.Enums;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;

    public class TicketInListViewModel : IMapFrom<Ticket>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int TicketStatusId { get; set; }

        public string TicketStatusName { get; set; }

        public string Content { get; set; }
    }
}
