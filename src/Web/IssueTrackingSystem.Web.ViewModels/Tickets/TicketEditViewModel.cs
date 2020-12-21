namespace IssueTrackingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Ganss.XSS;
    // using IssueTrackingSystem.Data.Common.Enums;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;

    public class TicketEditViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public int StatusId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TicketStatusItems { get; set; }

        public int PriorityId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TicketPriorityItems { get; set; }
    }
}
