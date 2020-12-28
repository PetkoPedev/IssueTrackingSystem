namespace IssueTrackingSystem.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;

    public class AllCategoriesViewModel : PagingViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
