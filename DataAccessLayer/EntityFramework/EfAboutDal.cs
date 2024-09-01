using DataAccessLayer.Abstracts;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

// burda hem generic sınıfı hemde entity'e ait olan interface i kalıtım yaptık çünkü
// ilerde crud işlemlerinin dışında bu entity'2 e ait olan fazla bir işlem yapmak gerektiğinde 
// imzasını verip kullanabilmemiz için
public class EfAboutDal:GenericRepository<About>,IAboutDal
{
    
}