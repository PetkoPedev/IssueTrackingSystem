﻿namespace IssueTrackingSystem.Web.Areas.Administration.Controllers
{
    using IssueTrackingSystem.Common;
    using IssueTrackingSystem.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
