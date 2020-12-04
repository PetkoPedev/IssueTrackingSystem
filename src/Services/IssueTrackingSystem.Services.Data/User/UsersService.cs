namespace IssueTrackingSystem.Services.Data.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Common;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;

    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UsersService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)

        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public async Task CreateModeratorAsync(RegisterUserInputModel input)
        {
            var userModerator = new ApplicationUser
            {
                Email = input.Email,
                UserName = input.Username,
                PasswordHash = input.Password,
                EmailConfirmed = true,
            };

            if (!await this.roleManager.RoleExistsAsync(GlobalConstants.ModeratorRoleName))
            {
                await this.roleManager.CreateAsync(new IdentityRole
                {
                    Name = GlobalConstants.ModeratorRoleName,
                });
            }

            await this.userManager.CreateAsync(userModerator, input.Password);
            await this.userManager.AddToRoleAsync(userModerator, GlobalConstants.ModeratorRoleName);
        }

        public async Task CreateUserAsync(RegisterUserInputModel input)
        {
            var userUser = new ApplicationUser
            {
                Email = input.Email,
                UserName = input.Username,
                PasswordHash = input.Password,
                EmailConfirmed = true,
            };

            if (!await this.roleManager.RoleExistsAsync(GlobalConstants.UserRoleName))
            {
                await this.roleManager.CreateAsync(new IdentityRole
                {
                    Name = GlobalConstants.UserRoleName,
                });
            }

            await this.userManager.CreateAsync(userUser, input.Password);
            await this.userManager.AddToRoleAsync(userUser, GlobalConstants.UserRoleName);
        }
    }
}
