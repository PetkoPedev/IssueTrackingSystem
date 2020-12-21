namespace IssueTrackingSystem.Services.Data.Ticket
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    // using IssueTrackingSystem.Data.Common.Enums;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Web.ViewModels.Tickets;

    public interface ITicketsService
    {
        Task<int> CreateAsync(string title, string content, int categoryId, string userId, int ticketStatus, int ticketPriority);

        IEnumerable<TicketInListViewModel> GetAll(int page, int itemsPerPage = 4);

        int GetCount();

        Task<T> GetById<T>(int id);

        Task<int> DeleteAsync(int id);

        Task EditAsync(int id, int categoryId, int ticketStatus, int ticketPriority);
    }
}
