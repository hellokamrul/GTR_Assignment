using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using GTR_Assign.Context;
using GTR_Assign.Interface.Manager;
using GTR_Assign.Models;
using GTR_Assign.Repository;


namespace GTR_Assign.Manager
{
    public class ProductManager : CommonManager<Product>, IProductManager
    {


        public ProductManager(EshopDbContext _dbContext) : base(new ProductRepository(_dbContext))
        {
        }
        public ICollection<Product> GetAll(string title)
        {
            return Get(c => c.Name.ToLower() == title.ToLower());
        }


        public Product GetById(int id)
        {
            return GetFirstOrDefault(x => x.Id == id);
        }

        public ICollection<Product> GetProducts(int page, int pageSize)
        {
            if (page <= 1)
            {
                page = 0;
            }
            int totalNumber = page * pageSize;
            return GetAll().Skip(totalNumber).Take(pageSize).ToList();
        }

        public ICollection<Product> SearchProduct(string text)
        {
            text = text.ToLower();
            return Get(c => c.Name.ToLower().Contains(text));
        }


    }
}
