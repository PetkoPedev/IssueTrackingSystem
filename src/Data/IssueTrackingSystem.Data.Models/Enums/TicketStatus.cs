namespace IssueTrackingSystem.Data.Models.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum TicketStatus
    {
        Open = 0,
        Pending = 1,
        Resolved = 2,
        Closed = 3,
        WaitingOnThirdParty = 4,
        Escalated = 5,
    }
}
