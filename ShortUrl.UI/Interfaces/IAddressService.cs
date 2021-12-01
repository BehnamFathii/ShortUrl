using CSharpFunctionalExtensions;
using ShortUrl.UI.ViewModels;

namespace ShortUrl.UI.Interfaces
{
    public interface IAddressService
    {
        Result<AddressItemViewModel> GetAddress(Guid addressId);
        Result<Guid> AddAddress(AddAddressViewModel vm);
    }
}
