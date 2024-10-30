using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AnnouncementManager : IAnnouncementService
{
    IAnnouncementDal _announcementDal;

    public AnnouncementManager(IAnnouncementDal announcementDal)
    {
        _announcementDal = announcementDal;
    }
    public void TAdd(Announcement t)
    {
        _announcementDal.Insert(t);
    }

    public void TDelete(Announcement t)
    {
        _announcementDal.Delete(t);
    }

    public void TUpdate(Announcement t)
    {
        _announcementDal.Update(t);
    }
    

    public List<Announcement> TGetList()
    {
        return _announcementDal.GetList();
    }

    public Announcement TGetById(int id)
    {
        var value =  _announcementDal.GetById(id);
        return value;
    }
    
}