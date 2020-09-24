using IssueTrackingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTrackingSystem.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> article)
        {
            article.HasKey(a => a.ArticleId);

            article.Property(a => a.ArticleName)
                .HasMaxLength(25)
                .IsRequired(true)
                .IsUnicode(true);

            article.Property(a => a.Content)
                .HasMaxLength(250)
                .IsRequired(true)
                .IsUnicode(true);

            article.HasOne(a => a.Author)
                .WithMany(at => at.Articles)
                .HasForeignKey(a => a.AuthorId);
        }
    }
}
