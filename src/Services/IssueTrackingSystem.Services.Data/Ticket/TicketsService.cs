    namespace IssueTrackingSystem.Services.Data.Ticket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Common.Enums;
    using IssueTrackingSystem.Data.Common.Repositories;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;
    using IssueTrackingSystem.Web.ViewModels.Tickets;

    public class TicketsService : ITicketsService
    {
        private readonly IDeletableEntityRepository<Ticket> ticketRepository;

        public TicketsService(IDeletableEntityRepository<Ticket> ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        public async Task<int> CreateAsync(string title, string content, int categoryId, TicketStatus ticketStatus, TicketPriority ticketPriority, string userId)
        {
            var ticket = new Ticket
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                TicketStatus = TicketStatus.Open,
                TicketPriority = TicketPriority.Low,
                UserId = userId,
            };

            await this.ticketRepository.AddAsync(ticket);
            await this.ticketRepository.SaveChangesAsync();

            return ticket.Id;
        }

        public IEnumerable<TicketInListViewModel> GetAll(int page, int itemsPerPage = 4)
        {
            var tickets = this.ticketRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new TicketInListViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    Content = x.Content,
                }).ToList();

            return tickets;
        }

        public Ticket GetById<Ticket>(int id)
        {
            var ticket = this.ticketRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<Ticket>()
                .FirstOrDefault();

            return ticket;
        }

        public int GetCount()
        {
            return this.ticketRepository.All().Count();
        }
    }
}
