using IssueTrackingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTrackingSystem.Data.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> note)
        {
            note.HasKey(n => n.NoteId);

            note.Property(n => n.Name)
                .HasMaxLength(25)
                .IsRequired(true)
                .IsUnicode(true);

            note.Property(n => n.Content)
                .HasMaxLength(500)
                .IsRequired(true)
                .IsUnicode(true);

            note.HasOne(n => n.Author)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.AuthorId);
        }
    }
}
