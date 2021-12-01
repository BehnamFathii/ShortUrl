using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.UI.Infra;
using ShortUrl.UI.Interfaces;
using ShortUrl.UI.ViewModels;

namespace ShortUrl.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlController : BaseController
    {
        private readonly IAddressService _addressService;

        public ShortUrlController(IAddressService addressService)
        {
            _addressService = addressService;
        }


        [HttpPost]
        public IActionResult AddAddress(AddAddressViewModel vm)
        {
            var canInsert = Validation.IsValid(vm);
            if (canInsert.IsFailure)
            {
                return Error(canInsert.Error);
            }
            var result = _addressService.AddAddress(vm);

            return FromResult(result);
        }

        [HttpGet("{addressId}")]
        public IActionResult GetAddress(Guid addressId)
        {     
            var result = _addressService.GetAddress(addressId);
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return Ok(result.Value);
        }
    }
}
