namespace IssueTrackingSystem.Services.Data.Counts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Services.Data.Models;

    public interface IGetCountsService
    {
        CountsDto GetCounts();
    }
}
