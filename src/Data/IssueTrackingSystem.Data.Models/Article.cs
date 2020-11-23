using IssueTrackingSystem.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTrackingSystem.Data.Models
{
    public class Article : BaseDeletableModel<int>
    {
        public string ArticleName { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
