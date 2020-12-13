namespace IssueTrackingSystem.Web.ViewModels.Notes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NoteInListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }
    }
}
