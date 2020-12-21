namespace IssueTrackingSystem.Services.Data.Priorities
{
    using IssueTrackingSystem.Data.Common.Repositories;
    using IssueTrackingSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PrioritiesService : IPrioritiesService
    {
        private readonly IDeletableEntityRepository<TicketPriority> priorityRepository;

        public PrioritiesService(IDeletableEntityRepository<TicketPriority> priorityRepository)
        {
            this.priorityRepository = priorityRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllPrioritiesAsKeyValuePairs()
        {
            return this.priorityRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
