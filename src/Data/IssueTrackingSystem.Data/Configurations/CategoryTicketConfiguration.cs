namespace IssueTrackingSystem.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryTicketConfiguration : IEntityTypeConfiguration<CategoryTicket>
    {
        public void Configure(EntityTypeBuilder<CategoryTicket> categoryTicket)
        {
            categoryTicket.HasKey(ct => new { ct.CategoryId, ct.TicketId });
        }
    }
}
