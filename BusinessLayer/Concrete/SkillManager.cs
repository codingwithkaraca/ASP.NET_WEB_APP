using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class SkillManager : ISkillService
{
    ISkillDal _skillDal;

    public SkillManager(ISkillDal skillDal)
    {
        _skillDal = skillDal;
    }

    public void TAdd(Skill t)
    {
        _skillDal.Insert(t);
    }

    public void TDelete(Skill t)
    {
        _skillDal.Delete(t);
    }

    public void TUpdate(Skill t)
    {
        _skillDal.Update(t);
    }

    public List<Skill> TGetList()
    {
        return _skillDal.GetList();
    }

    public Skill TGetById(int id)
    {
        return _skillDal.GetById(id);
    }

    public List<Skill> TGetListbyFilter()
    {
        throw new NotImplementedException();
    }
}