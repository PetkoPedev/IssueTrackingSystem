namespace IssueTrackingSystem.Web.ViewModels.Notes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NotesListViewModel : PagingViewModel
    {
        public IEnumerable<NoteInListViewModel> Notes { get; set; }
    }
}
