using EF.Core.Repository.Interface.Manager;
using GTR_Assign.Models;


namespace GTR_Assign.Interface.Manager
{
    public interface IProductManager : ICommonManager<Product>
    {
        Product GetById(int id);
      
        ICollection<Product> GetAll(string title);
        ICollection<Product> SearchProduct(string text);
        ICollection<Product> GetProducts(int page, int pageSize);

    }
}
