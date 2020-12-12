namespace IssueTrackingSystem.Services.Data.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Web.ViewModels.Articles;

    public interface IArticlesService
    {
        Task<int> CreateAsync(string articleName, string content, int categoryId, string userId);

        int GetCount();

        T GetById<T>(int id);

        IEnumerable<ArticleInListViewModel> GetAll(int page, int itemsPerPage = 12);
    }
}
