using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ContactManager: IContactService
{
    IContactDal _contactDal;
    
    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public void TAdd(Contact t)
    {
        _contactDal.Insert(t);
    }

    public void TDelete(Contact t)
    {
        _contactDal.Delete(t);
    }

    public void TUpdate(Contact t)
    {
        _contactDal.Update(t);
    }

    public List<Contact> TGetList()
    {
        return _contactDal.GetList();
    }

    public Contact TGetById(int id)
    {
        return _contactDal.GetById(id);
    }

    public List<Contact> TGetListbyFilter()
    {
        throw new NotImplementedException();
    }
}