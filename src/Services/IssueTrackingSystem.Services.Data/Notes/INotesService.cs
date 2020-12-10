namespace IssueTrackingSystem.Services.Data.Notes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Models;

    public interface INotesService
    {
        Task<int> CreateAsync(string name, string content, string authorId);

        T GetById<T>(int id);

        int GetCount();
    }
}
