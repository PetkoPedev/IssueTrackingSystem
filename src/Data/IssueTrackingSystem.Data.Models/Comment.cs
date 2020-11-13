using IssueTrackingSystem.Data.Common.Models;

namespace IssueTrackingSystem.Data.Models
{
    public class Comment : BaseDeletableModel<int>
    {
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        //public int? ParentId { get; set; }

        //public virtual Comment Parent { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}