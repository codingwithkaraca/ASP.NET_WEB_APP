using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ServiceManager:IServiceService
{
    IServiceDal _serviceDal;

    public ServiceManager(IServiceDal serviceDal)
    {
        _serviceDal = serviceDal;
    }

    public void TAdd(Service t)
    {
        _serviceDal.Insert(t);
    }

    public void TDelete(Service t)
    {
        _serviceDal.Delete(t);
    }

    public void TUpdate(Service t)
    {
        _serviceDal.Update(t);
    }

    public List<Service> TGetList()
    {
        return _serviceDal.GetList();
    }

    public Service TGetById(int id)
    {
        return _serviceDal.GetById(id);
    }
}