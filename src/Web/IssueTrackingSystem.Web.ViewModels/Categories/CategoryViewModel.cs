namespace IssueTrackingSystem.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;

    public class CategoryViewModel : IMapFrom<TicketCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
