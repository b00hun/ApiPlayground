using ApiPlayground.Data;
using ApiPlayground.Models;
using ApiPlayground.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayground.Controllers
{
    [Route("api/villaAPI")]
    [ApiController]
    
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult <IEnumerable<VillaDTO>> GetVillas()
        {

            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id==0)
            {
                return BadRequest();

            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }
    }
}
