using DataAccessLayer.Abstracts;
using DataAccessLayer.Concretes;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfUserMessageDal : GenericRepository<UserMessage>, IUserMessageDal
{
    public List<UserMessage> GetUserMessagesWithUser()
    {
        using (var c = new Context())
        {
            return c.UserMessages.Include(x => x.User).ToList();
            
        }
    }
}