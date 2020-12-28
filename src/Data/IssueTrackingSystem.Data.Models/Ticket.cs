namespace IssueTrackingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mime;
    using System.Text;

    using IssueTrackingSystem.Data.Common.Models;

    public class Ticket : BaseDeletableModel<int>
    {
        public Ticket()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public int TicketStatusId { get; set; }

        public virtual TicketStatus TicketStatus { get; set; }

        public int TicketPriorityId { get; set; }

        public virtual TicketPriority TicketPriority { get; set; }
    }
}
