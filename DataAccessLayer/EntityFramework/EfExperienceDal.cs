using DataAccessLayer.Abstracts;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;


public class EfExperienceDal: GenericRepository<Experience>, IExperienceDal
{
    
}