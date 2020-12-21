namespace IssueTrackingSystem.Services.Data.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);

        Task<int> CreateAsync(string name);

        IEnumerable<KeyValuePair<string, string>> GetAllCategoriesAsKeyValuePairs();
    }
}
