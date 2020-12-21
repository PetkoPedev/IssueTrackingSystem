namespace IssueTrackingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Common.Models;

    public class TicketStatus : BaseDeletableModel<int>
    {
        public TicketStatus()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
