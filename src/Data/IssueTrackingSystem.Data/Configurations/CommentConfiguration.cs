using IssueTrackingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTrackingSystem.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> comment)
        {
            comment.HasKey(c => c.Id);

            comment.Property(t => t.Content)
                .HasMaxLength(500)
                .IsRequired(true)
                .IsUnicode(true);

            comment.HasOne(c => c.Ticket)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TicketId);

            comment.HasOne(c => c.User)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.UserId);
        }
    }
}
