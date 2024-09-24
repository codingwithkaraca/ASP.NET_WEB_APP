using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class TodoListManager : ITodoListService
{
    private ITodoListDal _todoListDal;

    public TodoListManager(ITodoListDal todoListDal)
    {
        _todoListDal = todoListDal;
    }
    
    public void TAdd(TodoList t)
    {
        throw new NotImplementedException();
    }

    public void TDelete(TodoList t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(TodoList t)
    {
        throw new NotImplementedException();
    }

    public List<TodoList> TGetList()
    {
        return _todoListDal.GetList();
    }

    public TodoList TGetById(int id)
    {
        throw new NotImplementedException();
    }
}