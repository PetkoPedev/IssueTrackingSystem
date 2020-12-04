namespace IssueTrackingSystem.Services.Data.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Web.ViewModels.Users;

    public interface IUsersService
    {
        Task CreateModeratorAsync(RegisterUserInputModel input);

        Task CreateUserAsync(RegisterUserInputModel input);
    }
}
