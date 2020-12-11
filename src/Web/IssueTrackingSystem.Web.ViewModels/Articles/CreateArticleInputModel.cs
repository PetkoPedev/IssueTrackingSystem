namespace IssueTrackingSystem.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;
    using IssueTrackingSystem.Web.ViewModels.Categories;

    public class CreateArticleInputModel : IMapTo<Article>
    {
        public string ArticleName { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
