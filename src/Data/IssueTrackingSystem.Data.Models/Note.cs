namespace IssueTrackingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Common.Models;

    public class Note : BaseDeletableModel<int>
    {
        public int NoteId { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
