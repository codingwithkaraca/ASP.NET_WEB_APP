using EntityLayer.Concrete;

namespace DataAccessLayer.Abstracts;

public interface IUserMessageDal : IGenericDal<UserMessage>
{
    public List<UserMessage> GetUserMessagesWithUser();
}