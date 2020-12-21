namespace IssueTrackingSystem.Services.Data.Counts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // using IssueTrackingSystem.Data.Common.Enums;
    using IssueTrackingSystem.Data.Common.Repositories;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Data.Models;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Ticket> ticketRepository;
        private readonly IDeletableEntityRepository<Note> noteRepository;
        private readonly IDeletableEntityRepository<Article> articleRepository;

        public GetCountsService(
            IDeletableEntityRepository<Ticket> ticketRepository,
            IDeletableEntityRepository<Note> noteRepository,
            IDeletableEntityRepository<Article> articleRepository)
        {
            this.ticketRepository = ticketRepository;
            this.noteRepository = noteRepository;
            this.articleRepository = articleRepository;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto
            {
                TicketsCount = this.ticketRepository.All().Count(),
                ArticlesCount = this.articleRepository.All().Count(),
                NotesCount = this.noteRepository.All().Count(),
            };

            return data;
        }
    }
}
