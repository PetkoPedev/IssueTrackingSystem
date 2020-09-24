using IssueTrackingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTrackingSystem.Data.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> ticket)
        {
            ticket.HasIndex(t => t.Title);
            ticket.HasKey(t => t.TicketId);

            ticket.Property(t => t.Title)
                .HasMaxLength(50)
                .IsRequired(true)
                .HasDefaultValue("New Ticket")
                .IsUnicode(true);

            ticket.Property(t => t.Content)
                .HasMaxLength(500)
                .IsRequired(true)
                .IsUnicode(true);

            ticket.HasMany(t => t.Comments)
                .WithOne(c => c.Ticket)
                .HasForeignKey(t => t.TicketId);
        }
    }
}
