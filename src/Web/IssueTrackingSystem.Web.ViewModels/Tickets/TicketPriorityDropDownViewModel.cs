namespace IssueTrackingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Models.Enums;
    using IssueTrackingSystem.Services.Mapping;

    public class TicketPriorityDropDownViewModel : IMapFrom<TicketPriority>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
