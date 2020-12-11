namespace IssueTrackingSystem.Services.Data.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;

    public interface IArticlesService
    {
        Task<int> CreateAsync(string articleName, string content, string userId, int categoryId);

        int GetCount();

        Article GetById<T>(int id);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);
    }
}
