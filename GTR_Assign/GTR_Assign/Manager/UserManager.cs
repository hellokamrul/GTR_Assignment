using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using GTR_Assign.Context;
using GTR_Assign.Interface.Manager;
using GTR_Assign.Models;
using GTR_Assign.Repository;

namespace GTR_Assign.Manager
{
    public class UserManager : CommonManager<User>, IUserManager
    {
        public UserManager(EshopDbContext _dbContext) : base(new UserRepository(_dbContext))
        {
        }
        public User GetById(int id)
        {
            return GetFirstOrDefault(x => x.Id == id);
        }
    }
}
