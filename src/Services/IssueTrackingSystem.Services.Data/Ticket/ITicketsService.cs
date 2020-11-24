namespace IssueTrackingSystem.Services.Data.Ticket
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models.Enums;

    public interface ITicketsService
    {
        Task<int> CreateAsync(string title, string content, string userId, int categoryId, TicketStatus ticketStatus, TicketPriority ticketPriority);
    }
}
