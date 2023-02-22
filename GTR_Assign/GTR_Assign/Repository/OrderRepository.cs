using EF.Core.Repository.Repository;
using GTR_Assign.Context;
using GTR_Assign.Interface.Repository;
using GTR_Assign.Models;
using Microsoft.EntityFrameworkCore;

namespace GTR_Assign.Repository
{
    public class OrderRepository : CommonRepository<Order>, IOrderRepository
    {
        public OrderRepository(EshopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
