namespace IssueTrackingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    // using IssueTrackingSystem.Data.Common.Enums;
    using IssueTrackingSystem.Data.Models;

    public class CreateTicketInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public int StatusId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TicketStatusItems { get; set; }

        public int PriorityId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TicketPriorityItems { get; set; }
    }
}
