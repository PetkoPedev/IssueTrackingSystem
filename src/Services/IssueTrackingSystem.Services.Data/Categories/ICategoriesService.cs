namespace IssueTrackingSystem.Services.Data.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Web.ViewModels.Categories;

    public interface ICategoriesService
    {
        public IEnumerable<CategoryViewModel> GetAll(int page, int itemsPerPage = 4);

        T GetByName<T>(string name);

        Task<int> CreateAsync(string name);

        IEnumerable<KeyValuePair<string, string>> GetAllCategoriesAsKeyValuePairs();

        int GetCount();
    }
}
