namespace IssueTrackingSystem.Services.Data.Articles
{
    using IssueTrackingSystem.Data.Common.Repositories;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<Article> articleRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public async Task<int> CreateAsync(string articleName, string content, string userId, int categoryId)
        {
            var article = new Article
            {
                ArticleName = articleName,
                Content = content,
                UserId = userId,
                CategoryId = categoryId,
            };

            await this.articleRepository.AddAsync(article);
            await this.articleRepository.SaveChangesAsync();

            return article.Id;
        }

        public int GetCount()
        {
            return this.articleRepository.All().Count();
        }

        public Article GetById<T>(int id)
        {
            var article = this.articleRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<Article>()
                .FirstOrDefault();

            return article;
        }
    }
}
