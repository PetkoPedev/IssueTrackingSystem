namespace IssueTrackingSystem.Services.Data.Ticket
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Common.Enums;
    using IssueTrackingSystem.Web.ViewModels.Tickets;

    public interface ITicketsService
    {
        Task<int> CreateAsync(string title, string content, int categoryId, string userId, TicketStatus ticketStatus, TicketPriority ticketPriority);

        IEnumerable<TicketInListViewModel> GetAll(int page, int itemsPerPage = 4);

        int GetCount();

        Ticket GetById<Ticket>(int id);
    }
}
