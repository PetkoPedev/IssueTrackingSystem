namespace IssueTrackingSystem.Services.Data.Notes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using IssueTrackingSystem.Data.Common.Repositories;
    using IssueTrackingSystem.Data.Models;
    using IssueTrackingSystem.Services.Mapping;
    using IssueTrackingSystem.Web.ViewModels.Notes;

    public class NoteService : INotesService
    {
        private readonly IDeletableEntityRepository<Note> noteRepository;

        public NoteService(IDeletableEntityRepository<Note> noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public async Task<int> CreateAsync(string name, string content, string authorId)
        {
            var note = new Note
            {
                Name = name,
                Content = content,
                AuthorId = authorId,
            };

            await this.noteRepository.AddAsync(note);
            await this.noteRepository.SaveChangesAsync();

            return note.Id;
        }

        public T GetById<T>(int id)
        {
            var note = this.noteRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return note;
        }

        public int GetCount()
        {
            return this.noteRepository.All().Count();
        }

        public IEnumerable<NoteInListViewModel> GetAll(int page, int itemsPerPage = 6)
        {
            var notes = this.noteRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new NoteInListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Content = x.Content,
                    AuthorId = x.AuthorId,
                }).ToList();

            return notes;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var note = this.noteRepository.AllAsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            this.noteRepository.Delete(note);
            await this.noteRepository.SaveChangesAsync();

            return note.Id;
        }
    }
}
