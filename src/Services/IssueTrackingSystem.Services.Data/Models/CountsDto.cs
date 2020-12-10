namespace IssueTrackingSystem.Services.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CountsDto
    {
        public int TicketsCount { get; set; }

        public int NotesCount { get; set; }

        public int ArticlesCount { get; set; }
    }
}
