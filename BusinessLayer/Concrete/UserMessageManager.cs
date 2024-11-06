using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class UserMessageManager : IUserMessageService
{
    IUserMessageDal _userMessageDal;

    public UserMessageManager(IUserMessageDal userMessageDal)
    {
        _userMessageDal = userMessageDal;

    }
    
    public void TAdd(UserMessage t)
    {
        throw new NotImplementedException();
    }

    public void TDelete(UserMessage t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(UserMessage t)
    {
        throw new NotImplementedException();
    }

    public List<UserMessage> TGetList()
    {
        return _userMessageDal.GetList();
    }

    public UserMessage TGetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<UserMessage> TGetListbyFilter()
    {
        throw new NotImplementedException();
    }

    public List<UserMessage> GetUserMessageWithUserService()
    {
        return _userMessageDal.GetUserMessagesWithUser();
    }
}