using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard;

public class TodoList : ViewComponent
{
    private TodoListManager todoListManager = new TodoListManager(new EfTodoListDal());
    
    public IViewComponentResult Invoke()
    {
        var values = todoListManager.TGetList();
        
        return View(values);
    }
}