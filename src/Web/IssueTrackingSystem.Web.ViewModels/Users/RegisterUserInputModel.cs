namespace IssueTrackingSystem.Web.ViewModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Models;

    public class RegisterUserInputModel
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public ApplicationRole SelectedRole { get; set; }
    }
}
