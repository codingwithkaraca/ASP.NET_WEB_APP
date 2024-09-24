using DataAccessLayer.Abstracts;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfTodoListDal : GenericRepository<TodoList>, ITodoListDal
{
    
}