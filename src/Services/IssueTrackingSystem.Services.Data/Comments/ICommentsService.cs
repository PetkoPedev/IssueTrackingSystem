namespace IssueTrackingSystem.Services.Data.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task<int> CreateAsync(int ticketId, string userId, string content, int? parentId = null);

        bool IsInTicketId(int commentId, int ticketId);
    }
}
