namespace IssueTrackingSystem.Services.Data.Categories
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
        private readonly IDeletableEntityRepository<TicketCategory> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<TicketCategory> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<int> CreateAsync(string name)
        {
            var category = new TicketCategory
            {
                Name = name,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();

            return category.Id;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<T> allCategories = (IQueryable<T>)this.categoriesRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                allCategories = allCategories.Take(count.Value);
            }

            return allCategories.To<T>().ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCategoriesAsKeyValuePairs()
        {
            return this.categoriesRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public T GetByName<T>(string name)
        {
            var category = this.categoriesRepository.All()
                .Where(x => x.Name == name).To<T>().FirstOrDefault();

            return category;
        }
    }
}
