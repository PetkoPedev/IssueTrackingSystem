namespace IssueTrackingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserTicket
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }
    }
}
