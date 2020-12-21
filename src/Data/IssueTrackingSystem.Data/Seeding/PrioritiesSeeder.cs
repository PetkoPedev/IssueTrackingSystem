namespace IssueTrackingSystem.Data.Seeding
{
    using IssueTrackingSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PrioritiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Priorities.Any())
            {
                return;
            }

            var priorities = new List<string> { "Low", "Middle", "High" };
            foreach (var priority in priorities)
            {
                await dbContext.Priorities.AddAsync(new TicketPriority
                {
                    Name = priority,
                });
            }
        }
    }
}
