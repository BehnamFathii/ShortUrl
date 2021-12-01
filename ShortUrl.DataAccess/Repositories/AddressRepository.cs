using ShortUrl.DataAccess.DataModels;
using ShortUrl.DataAccess.Interfaces;

namespace ShortUrl.DataAccess.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressContext _AddressDbContext;

        public AddressRepository(AddressContext AddressDbContext)
        {
            _AddressDbContext = AddressDbContext;
        }

        public bool Exists(Guid addressId)
        {
            return _AddressDbContext.Addresses.Any(c => c.AddressId == addressId);
        }
        public Address Load(Guid addressId)
        {
            return _AddressDbContext.Addresses.FirstOrDefault(o => o.AddressId == addressId);
        }

        public void Add(Address entity)
        {
            _AddressDbContext.Addresses.Add(entity);
            _AddressDbContext.SaveChanges();
        }

        public void Edit(Address entity)
        {
            _AddressDbContext.Addresses.Update(entity);
            _AddressDbContext.SaveChanges();
        }
    }
}
