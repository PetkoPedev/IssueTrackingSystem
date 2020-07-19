using IssueTrackingSystem.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTrackingSystem.Data.Models
{
    public class Article : BaseDeletableModel<int>
    {
        public int ArticleId { get; set; }

        public string ArticleName { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
