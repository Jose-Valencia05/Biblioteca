using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Book> Books { get; }
        IRepository<Author> Authors { get; }
        IRepository<Genre> Genres { get; }
        void SaveChanges();
    }
}
