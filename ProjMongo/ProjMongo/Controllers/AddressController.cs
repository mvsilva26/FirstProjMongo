using Microsoft.AspNetCore.Mvc;
using ProjMongo.Model;
using ProjMongo.Service;
using System.Collections.Generic;

namespace ProjMongo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() =>
            _addressService.Get();


        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }


        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            _addressService.Create(address);

            return CreatedAtRoute("GetAddress", new { id = address.Id.ToString() }, address);
        }


        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Address addressIn)
        {
            var address = _addressService.Get(id);

            if (address == null)
            {
                return NotFound();
            }

            _addressService.Update(id, addressIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var address = _addressService.Get(id);

            if (address == null)
            {
                return NotFound();
            }

            _addressService.Remove(address.Id);

            return NoContent();
        }




    }
}
