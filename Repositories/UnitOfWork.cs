using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Book> Books { get; }

        public IRepository<Author> Authors { get; }

        public IRepository<Genre> Genres { get; }

        public UnitOfWork()
        {
            Books = new Repository<Book>();
            Authors = new Repository<Author>();
            Genres = new Repository<Genre>();
        }
        public void SaveChanges()
        {
            //Guardar e base de datos, archivo ...
        }
    }
}
