namespace IssueTrackingSystem.Data.Models
{
    using System.Collections.Generic;

    using IssueTrackingSystem.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}