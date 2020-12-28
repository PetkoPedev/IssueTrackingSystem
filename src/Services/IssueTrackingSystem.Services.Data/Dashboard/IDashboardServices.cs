namespace IssueTrackingSystem.Services.Data.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IDashboardServices
    {
        int GetArticlesCounts();

        int GetCategoriesCounts();

        int GetNotesCounts();

        int GetTicketsCounts();

    }
}
