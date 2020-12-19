namespace IssueTrackingSystem.Web.ViewModels.Notes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Ganss.XSS;

    public class NoteInListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string ShortContent =>
            this.Content?.Length > 50
            ? this.Content?.Substring(0, 50) + "..."
            : this.Content;

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string AuthorId { get; set; }
    }
}
