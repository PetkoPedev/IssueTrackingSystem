namespace IssueTrackingSystem.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;

    public class SingleArticleViewModel : IMapFrom<Article>
    {
        public string ArticleName { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public string UserUserName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryCategoryName { get; set; }
    }
}
