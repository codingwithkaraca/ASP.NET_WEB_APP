using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class MessageManager: IMessageService
{
    IMessageDal _messageDal;

    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }

    public void TAdd(Message t)
    {
        _messageDal.Insert(t);
    }

    public void TDelete(Message t)
    {
        _messageDal.Delete(t);
    }

    public void TUpdate(Message t)
    {
        _messageDal.Update(t);
    }

    public List<Message> TGetList()
    {
        return _messageDal.GetList();
    }

    public Message TGetById(int id)
    {
        return _messageDal.GetById(id);
    }

    public List<Message> TGetListbyFilter()
    {
        throw new NotImplementedException();
    }
}