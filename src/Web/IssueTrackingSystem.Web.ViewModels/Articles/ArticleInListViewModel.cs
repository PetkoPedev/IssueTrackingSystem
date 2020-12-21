namespace IssueTrackingSystem.Web.ViewModels.Articles
{
    public class ArticleInListViewModel
    {
        public int Id { get; set; }

        public string ArticleName { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public int ArticleCategoryId { get; set; }
    }
}
