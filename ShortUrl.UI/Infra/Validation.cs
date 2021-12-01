using CSharpFunctionalExtensions;
using ShortUrl.UI.ViewModels;

namespace ShortUrl.UI.Infra
{
    public static class Validation
    {
        public static Result IsValid(AddAddressViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.AddressUrl))
            {
                return Result.Failure("آدرس خود را وارد کنید");
            }
            return Result.Success();
        }
    }
}
