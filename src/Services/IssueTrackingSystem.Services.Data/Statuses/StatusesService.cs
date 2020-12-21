namespace IssueTrackingSystem.Services.Data.Statuses
{
    using IssueTrackingSystem.Data.Common.Repositories;
    using IssueTrackingSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StatusesService : IStatusesService
    {
        private readonly IDeletableEntityRepository<TicketStatus> ticketStatusRepository;

        public StatusesService(IDeletableEntityRepository<TicketStatus> ticketStatusRepository)
        {
            this.ticketStatusRepository = ticketStatusRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllStatusesAsKeyValuePairs()
        {
            return this.ticketStatusRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
