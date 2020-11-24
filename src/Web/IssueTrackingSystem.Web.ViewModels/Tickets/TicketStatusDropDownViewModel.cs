namespace IssueTrackingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Data.Models.Enums;
    using IssueTrackingSystem.Services.Mapping;

    public class TicketStatusDropDownViewModel : IMapFrom<TicketStatus>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
