namespace IssueTrackingSystem.Services.Data.Ticket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using IssueTrackingSystem.Data.Common.Repositories;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Data.Models.Enums;

    public class TicketsService : ITicketsService
    {
        private readonly IDeletableEntityRepository<Ticket> ticketRepository;

        public TicketsService(IDeletableEntityRepository<Ticket> ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        public async Task<int> CreateAsync(string title, string content, int categoryId, TicketStatus ticketStatus, TicketPriority ticketPriority)
        {
            var ticket = new Ticket
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                TicketStatus = ticketStatus,
                TicketPriority = ticketPriority,
            };

            await this.ticketRepository.AddAsync(ticket);
            await this.ticketRepository.SaveChangesAsync();

            return ticket.Id;
        }
    }
}
