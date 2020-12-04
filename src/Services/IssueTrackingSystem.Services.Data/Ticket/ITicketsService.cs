namespace IssueTrackingSystem.Services.Data.Ticket
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using IssueTrackingSystem.Data.Common.Enums;

    public interface ITicketsService
    {
        Task<int> CreateAsync(string title, string content, int categoryId, TicketStatus ticketStatus, TicketPriority ticketPriority);
    }
}
