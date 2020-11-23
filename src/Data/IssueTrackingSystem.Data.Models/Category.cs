namespace IssueTrackingSystem.Data.Models
{
    using System.Collections.Generic;

    using IssueTrackingSystem.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Tickets = new HashSet<Ticket>();
            this.Articles = new HashSet<Article>();
        }

        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}