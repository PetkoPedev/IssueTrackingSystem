namespace IssueTrackingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mime;
    using System.Text;

    using IssueTrackingSystem.Data.Common.Models;
    using IssueTrackingSystem.Data.Models.Enums;

    public class Ticket : BaseDeletableModel<int>
    {
        public Ticket()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int TicketId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual TicketStatus TicketStatus { get; set; }

        public virtual TicketPriority TicketPriority { get; set; }
    }
}
