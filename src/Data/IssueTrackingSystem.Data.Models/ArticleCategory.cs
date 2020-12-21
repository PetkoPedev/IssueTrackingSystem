namespace IssueTrackingSystem.Data.Models
{
    using System.Collections.Generic;

    using IssueTrackingSystem.Data.Common.Models;

    public class ArticleCategory : BaseDeletableModel<int>
    {
        public ArticleCategory()
        {
            this.Articles = new HashSet<Article>();
        }

        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}