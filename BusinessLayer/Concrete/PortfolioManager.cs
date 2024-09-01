using BusinessLayer.Abstract;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class PortfolioManager: IPortfolioService
{
    
    IPortfolioDal _portfolioDal;

    public PortfolioManager(IPortfolioDal portfolioDal)
    {
        _portfolioDal = portfolioDal;
    }

    public void TAdd(Portfolio t)
    {
        _portfolioDal.Insert(t);
    }

    public void TDelete(Portfolio t)
    {
        _portfolioDal.Delete(t);
    }

    public void TUpdate(Portfolio t)
    {
        _portfolioDal.Update(t);
    }

    public List<Portfolio> TGetList()
    {
        return _portfolioDal.GetList();
    }

    public Portfolio TGetById(int id)
    {
        return _portfolioDal.GetById(id);
    }
}