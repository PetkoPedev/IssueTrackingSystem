namespace IssueTrackingSystem.Services.Data.Statuses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStatusesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllStatusesAsKeyValuePairs();
    }
}
