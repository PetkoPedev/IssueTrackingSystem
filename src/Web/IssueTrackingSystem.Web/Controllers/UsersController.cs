namespace IssueTrackingSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Data.User;
    using IssueTrackingSystem.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : BaseController
    {
        private readonly UsersService usersService;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult CreateUser()
        {
            var viewModel = new RegisterUserInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterUserInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.usersService.CreateUserAsync(input);
            return this.Redirect("/");
        }

        public IActionResult CreateModerator()
        {
            var viewModel = new RegisterUserInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateModerator(RegisterUserInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.usersService.CreateModeratorAsync(input);
            return this.Redirect("/");
        }
    }
}
