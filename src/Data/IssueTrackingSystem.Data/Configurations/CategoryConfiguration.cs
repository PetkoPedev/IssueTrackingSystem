using IssueTrackingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTrackingSystem.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.HasKey(cat => cat.CategoryId);

            category.Property(cat => cat.CategoryName)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            category.HasMany(cat => cat.Tickets)
                .WithOne(t => t.Category)
                .HasForeignKey(cat => cat.TicketId);
        }
    }
}
