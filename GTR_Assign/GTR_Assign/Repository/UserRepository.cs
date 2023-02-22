using EF.Core.Repository.Repository;
using GTR_Assign.Context;
using GTR_Assign.Interface.Repository;
using GTR_Assign.Models;

namespace GTR_Assign.Repository
{
    public class UserRepository:CommonRepository<User>, IUserRepository
    {
        public UserRepository(EshopDbContext dbContext) : base(dbContext)
    {
    }
}
}
