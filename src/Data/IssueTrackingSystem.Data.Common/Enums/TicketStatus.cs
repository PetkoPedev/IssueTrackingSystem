namespace IssueTrackingSystem.Data.Common.Enums
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public enum TicketStatus
    {
        [Display(Name ="Open")]
        Open = 0,
        [Display(Name = "Pending")]
        Pending = 1,
        [Display(Name = "Resolved")]
        Resolved = 2,
        [Display(Name = "Closed")]
        Closed = 3,
        [Display(Name = "WaitingOnThirdParty")]
        WaitingOnThirdParty = 4,
        [Display(Name = "Escalated")]
        Escalated = 5,
    }
}
