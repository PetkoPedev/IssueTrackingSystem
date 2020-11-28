namespace IssueTrackingSystem.Services.Data.Category
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using IssueTrackingSystem.Data.Common.Repositories;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<int> CreateAsync(string name)
        {
            var category = new Category
            {
                Name = name,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();

            return category.Id;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Category> allCategories = this.categoriesRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                allCategories = allCategories.Take(count.Value);
            }

            return allCategories.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
            var category = this.categoriesRepository.All()
                .Where(x => x.Name == name).To<T>().FirstOrDefault();

            return category;
        }
    }
}
