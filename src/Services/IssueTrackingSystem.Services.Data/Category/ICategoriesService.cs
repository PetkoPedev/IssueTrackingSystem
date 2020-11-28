namespace IssueTrackingSystem.Services.Data.Category
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);

        Task<int> CreateAsync(string name);
    }
}
