namespace IssueTrackingSystem.Services.Data.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Common.Repositories;
    using IssueTrackingSystem.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task<int> CreateAsync(int ticketId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                TicketId = ticketId,
                UserId = userId,
                Content = content,
                ParentId = parentId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();

            return comment.Id;
        }

        public bool IsInTicketId(int commentId, int ticketId)
        {
            var commentTicketId = this.commentsRepository.All().Where(x => x.Id == commentId)
                .Select(x => x.TicketId).FirstOrDefault();
            return commentTicketId == ticketId;
        }
    }
}
