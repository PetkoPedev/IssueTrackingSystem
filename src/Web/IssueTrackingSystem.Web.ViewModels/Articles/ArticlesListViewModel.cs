namespace IssueTrackingSystem.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArticlesListViewModel : PagingViewModel
    {
        public IEnumerable<ArticleInListViewModel> Articles { get; set; }
    }
}
