namespace IssueTrackingSystem.Data.Models
{
    using System.Collections.Generic;

    using IssueTrackingSystem.Data.Common.Models;

    public class TicketCategory : BaseDeletableModel<int>
    {
        public TicketCategory()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
