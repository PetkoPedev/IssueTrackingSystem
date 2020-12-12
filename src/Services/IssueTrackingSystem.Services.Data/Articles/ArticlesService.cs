namespace IssueTrackingSystem.Services.Data.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Common.Repositories;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;
    using IssueTrackingSystem.Web.ViewModels.Articles;

    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<Article> articleRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public async Task<int> CreateAsync(string articleName, string content, int categoryId, string userId)
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

        public T GetById<T>(int id)
        {
            var article = this.articleRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return article;
        }

        public IEnumerable<ArticleInListViewModel> GetAll(int page, int itemsPerPage = 4)
        {
            var articles = this.articleRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new ArticleInListViewModel
                {
                    Id = x.Id,
                    ArticleName = x.ArticleName,
                    Content = x.Content,
                    CategoryId = x.CategoryId,
                    UserId = x.UserId,
                }).ToList();

            return articles;
        }
    }
}
