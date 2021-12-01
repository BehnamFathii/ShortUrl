using Microsoft.EntityFrameworkCore;
using ShortUrl.DataAccess.DataModels;

namespace ShortUrl.DataAccess
{
    public class AddressContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public AddressContext(DbContextOptions options) : base(options)
        {
        }
    }
}
