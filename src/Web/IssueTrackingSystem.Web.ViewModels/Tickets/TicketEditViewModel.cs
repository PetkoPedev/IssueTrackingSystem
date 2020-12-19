namespace IssueTrackingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Ganss.XSS;
    using IssueTrackingSystem.Data.Common.Enums;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;

    public class TicketEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public int TicketStatusId { get; set; }

        [Required]
        public TicketStatus TicketStatus { get; set; }

        public int TicketPriorityId { get; set; }

        [Required]
        public TicketPriority TicketPriority { get; set; }
    }
}
