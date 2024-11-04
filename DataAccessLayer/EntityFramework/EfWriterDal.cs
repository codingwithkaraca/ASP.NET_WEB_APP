using DataAccessLayer.Abstracts;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfWriterDal : GenericRepository<WriterMessage>, IWriterMessageDal
{
    
    
}