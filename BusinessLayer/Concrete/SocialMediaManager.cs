using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class SocialMediaManager: ISocialMediaService
{
    ISocialMediaDal _socialMediaDal;

    public SocialMediaManager(ISocialMediaDal socialMediaDal)
    {
        _socialMediaDal = socialMediaDal;
    }

    public void TAdd(SocialMedia t)
    {
        _socialMediaDal.Insert(t);
    }

    public void TDelete(SocialMedia t)
    {
        _socialMediaDal.Delete(t);
    }

    public void TUpdate(SocialMedia t)
    {
        _socialMediaDal.Update(t);
    }

    public List<SocialMedia> TGetList()
    {
        return _socialMediaDal.GetList();
    }

    public SocialMedia TGetById(int id)
    {
        return _socialMediaDal.GetById(id);
    }

    public List<SocialMedia> TGetListbyFilter()
    {
        throw new NotImplementedException();
    }
}