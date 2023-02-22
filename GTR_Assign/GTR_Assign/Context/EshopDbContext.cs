using GTR_Assign.Models;
using Microsoft.EntityFrameworkCore;

namespace GTR_Assign.Context
{
    public class EshopDbContext: DbContext
    {
        public EshopDbContext(DbContextOptions<EshopDbContext> options)
        : base(options)
        {
        }
        public  DbSet<Order> Orders { get; set; }

        public  DbSet<Product> Products { get; set; }

        public  DbSet<User> Users { get; set; }
    }
}
