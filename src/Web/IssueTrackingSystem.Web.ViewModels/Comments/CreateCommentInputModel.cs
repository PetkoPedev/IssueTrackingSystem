namespace IssueTrackingSystem.Web.ViewModels.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateCommentInputModel
    {
        public int TicketId { get; set; }

        public string Content { get; set; }
    }
}
