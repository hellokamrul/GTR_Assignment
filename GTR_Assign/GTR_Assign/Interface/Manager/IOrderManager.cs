using EF.Core.Repository.Interface.Manager;
using GTR_Assign.Models;

namespace GTR_Assign.Interface.Manager
{
    public interface IOrderManager : ICommonManager<Order>
    {
        Order GetById(int id);
    }
}
