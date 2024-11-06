using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class WriterMessageManager : IWriterMessageService
{
    IWriterMessageDal _writerMessageDal;

    public WriterMessageManager(IWriterMessageDal writerMessageDal)
    {
        _writerMessageDal = writerMessageDal;
    }
    
    public void TAdd(WriterMessage t)
    {
        _writerMessageDal.Insert(t);
    }

    public void TDelete(WriterMessage t)
    {
        _writerMessageDal.Delete(t);
    }

    public void TUpdate(WriterMessage t)
    {
        _writerMessageDal.Update(t);
    }

    public List<WriterMessage> TGetList()
    {
        var values = _writerMessageDal.GetList();
        return values;
    }

    public WriterMessage TGetById(int id)
    {
        var value =_writerMessageDal.GetById(id);

        return value;
    }

    public List<WriterMessage> TGetListbyFilter()
    {
        throw new NotImplementedException();
    }
    
    public List<WriterMessage> GetListSenderMessage(string p)
    {
        return _writerMessageDal.GetbyFilter(x => x.Sender == p);
    }

    public List<WriterMessage> GetListReceiverMessage(string p)
    { 
        return _writerMessageDal.GetbyFilter(x => x.Receiver == p);
    }
}