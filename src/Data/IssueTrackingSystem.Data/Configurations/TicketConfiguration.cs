namespace IssueTrackingSystem.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            // TODO
        }
    }
}
