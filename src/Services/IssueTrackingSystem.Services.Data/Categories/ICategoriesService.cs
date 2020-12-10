namespace IssueTrackingSystem.Services.Data.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;

    public interface ICategoriesService
    {
        IEnumerable<TCategory> GetAll<TCategory>(int? count = null);

        TCategory GetByName<TCategory>(string name);

        Task<int> CreateAsync(string name);
    }
}
