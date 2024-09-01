using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ExperienceManager : IExperienceService
{
    IExperienceDal _experienceDal;
    
    public ExperienceManager(IExperienceDal experienceDal)
    {
        _experienceDal = experienceDal;
    }


    public void TAdd(Experience t)
    {
        _experienceDal.Insert(t);
    }

    public void TDelete(Experience t)
    {
        _experienceDal.Delete(t);
    }

    public void TUpdate(Experience t)
    {
        _experienceDal.Update(t);
    }

    public List<Experience> TGetList()
    {
        return _experienceDal.GetList();
    }

    public Experience TGetById(int id)
    {
        return _experienceDal.GetById(id);
    }
}