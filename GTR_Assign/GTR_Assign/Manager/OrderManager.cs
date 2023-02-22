using EF.Core.Repository.Manager;
using GTR_Assign.Context;
using GTR_Assign.Interface.Manager;
using GTR_Assign.Models;
using GTR_Assign.Repository;

namespace GTR_Assign.Manager
{
    public class OrderManager : CommonManager<Order>, IOrderManager
    {
        public OrderManager(EshopDbContext _dbContext) : base(new OrderRepository(_dbContext))
        {
        }

        public Order GetById(int id)
        {
            return GetFirstOrDefault(x => x.Id == id);
        }
    }
}
