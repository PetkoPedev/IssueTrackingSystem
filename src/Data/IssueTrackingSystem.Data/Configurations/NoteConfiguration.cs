namespace IssueTrackingSystem.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            // TODO
        }
    }
}
