using CSharpFunctionalExtensions;
using ShortUrl.DataAccess.DataModels;
using ShortUrl.DataAccess.Interfaces;
using ShortUrl.UI.Interfaces;
using ShortUrl.UI.ViewModels;

namespace ShortUrl.UI.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Result<Guid> AddAddress(AddAddressViewModel vm)
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                AddressUrl = vm.AddressUrl
            };
            _addressRepository.Add(address);
            return Result.Success<Guid>(address.AddressId);
        }

        public Result<AddressItemViewModel> GetAddress(Guid addressId)
        {
            var addressVm = new AddressItemViewModel();
            var result = _addressRepository.Load(addressId);
            if (result != null)
            {
                addressVm.AddressUrl = result.AddressUrl;
                addressVm.View = result.View + 1;
                result.View = addressVm.View;
                _addressRepository.Edit(result);
                return Result.Success(addressVm);
            }
            return Result.Failure<AddressItemViewModel>("آدرس با این شناسه یافت نشد");
        }
    }
}
