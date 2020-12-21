﻿namespace IssueTrackingSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.TicketCategories.Any())
            {
                return;
            }

            var categories = new List<string> { "Hardware", "Software", "MS Office" };
            foreach (var category in categories)
            {
                await dbContext.TicketCategories.AddAsync(new TicketCategory
                {
                    Name = category,
                });
            }
        }
    }
}
