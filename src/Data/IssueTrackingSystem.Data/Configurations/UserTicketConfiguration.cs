using IssueTrackingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTrackingSystem.Data.Configurations
{
    public class UserTicketConfiguration : IEntityTypeConfiguration<UserTicket>
    {
        public void Configure(EntityTypeBuilder<UserTicket> builder)
        {
            // TODO
        }
    }
}
