using EF.Core.Repository.Interface.Manager;
using GTR_Assign.Models;
using Microsoft.Extensions.Hosting;
namespace GTR_Assign.Interface.Manager
{
    public interface IUserManager : ICommonManager<User>
    {
        User GetById(int id);
    }
}
