namespace IssueTrackingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Data.Models.Enums;

    public class CreateTicketInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public TicketStatus TicketStatus { get; set; }

        [Required]
        public TicketPriority TicketPriority { get; set; }
    }
}
