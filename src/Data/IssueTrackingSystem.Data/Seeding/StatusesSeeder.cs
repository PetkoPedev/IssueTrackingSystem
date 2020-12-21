namespace IssueTrackingSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;

    public class StatusesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Statuses.Any())
            {
                return;
            }

            var statuses = new List<string> { "Open", "Pending", "Closed" };
            foreach (var status in statuses)
            {
                await dbContext.Statuses.AddAsync(new TicketStatus
                {
                    Name = status,
                });
            }
        }
    }
}
