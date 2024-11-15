using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class WriterUserManager : IWriterUserService
{
    private IWriterUserDal _writerUserDal;
    
    public WriterUserManager(IWriterUserDal writerUserDal)
    {
        _writerUserDal = writerUserDal;
    }
    
    public void TAdd(WriterUser t)
    {
        _writerUserDal.Insert(t);
    }

    public void TDelete(WriterUser t)
    {
        _writerUserDal.Delete(t);
    }

    public void TUpdate(WriterUser t)
    {
        _writerUserDal.Update(t);
    }

    public List<WriterUser> TGetList()
    {
        var values = _writerUserDal.GetList();
        return values;
    }

    public WriterUser TGetById(int id)
    {
        var value =_writerUserDal.GetById(id);
        return value;
    }

    public List<WriterUser> TGetListbyFilter()
    {
        // şuanda boş dursun filtreli sorgu kullanacağım zaman doldurayım
        // var values = _writerUserDal.GetbyFilter();
        // return values;
        throw new NotImplementedException();
    }
}