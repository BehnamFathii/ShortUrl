using ShortUrl.DataAccess.DataModels;

namespace ShortUrl.DataAccess.Interfaces
{
    public interface IAddressRepository
    {
        bool Exists(Guid addressId);

        Address Load(Guid addressId);

        void Add(Address entity);
    }
}
