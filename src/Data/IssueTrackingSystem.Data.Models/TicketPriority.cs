namespace IssueTrackingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Common.Models;

    public class TicketPriority : BaseDeletableModel<int>
    {
        public TicketPriority()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
