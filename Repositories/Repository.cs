
namespace Biblioteca.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _data = new List<T>();
        public void Add(T entity)
        {
            _data.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _data.Remove(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _data;
        }

        public T GetById(int id)
        {
            return _data.FirstOrDefault(e => (int)e.GetType().GetProperty("Id").GetValue(e) == id);
        }

        public void Update(T entity)
        {
            var exisitingEntity = GetById( (int)entity.GetType().GetProperty("Id").GetValue(entity));
        }
    }
}
