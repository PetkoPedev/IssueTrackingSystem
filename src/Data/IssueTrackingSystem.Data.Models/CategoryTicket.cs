namespace IssueTrackingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryTicket
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }
    }
}
