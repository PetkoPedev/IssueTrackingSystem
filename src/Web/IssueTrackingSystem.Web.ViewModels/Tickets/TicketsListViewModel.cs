namespace IssueTrackingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TicketsListViewModel : PagingViewModel
    {
        public IEnumerable<TicketInListViewModel> Tickets { get; set; }

    }
}
