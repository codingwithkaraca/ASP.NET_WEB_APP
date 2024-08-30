using DataAccessLayer.Abstracts;

namespace DataAccessLayer.Repository;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    public void Insert(T t)
    {
        throw new NotImplementedException();
    }

    public void Delete(T t)
    {
        throw new NotImplementedException();
    }

    public void Update(T t)
    {
        throw new NotImplementedException();
    }

    public List<T> GetList()
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }
}