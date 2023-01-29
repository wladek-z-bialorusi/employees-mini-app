namespace EmployeesMiniApp.DAL
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T? GetById(int id);

        public void Add(T entity);

        public void Update(T entity);

        public void Remove(T entity);
    }
}
