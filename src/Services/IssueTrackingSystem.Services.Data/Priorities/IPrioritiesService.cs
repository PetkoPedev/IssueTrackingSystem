namespace IssueTrackingSystem.Services.Data.Priorities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IPrioritiesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllPrioritiesAsKeyValuePairs();
    }
}
