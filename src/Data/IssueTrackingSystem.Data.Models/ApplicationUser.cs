﻿// ReSharper disable VirtualMemberCallInConstructor
namespace IssueTrackingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    using IssueTrackingSystem.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Tickets = new HashSet<Ticket>();
            this.Comments = new HashSet<Comment>();
            this.Notes = new HashSet<Note>();
            this.Articles = new HashSet<Article>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
