namespace IssueTrackingSystem.Web.ViewModels.Notes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;

    public class SingleNoteViewModel : IMapFrom<Note>
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public string UserNameAuthor { get; set; }
    }
}
