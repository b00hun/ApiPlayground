﻿using ApiPlayground.Data;
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

        [HttpGet("{id:int}",Name="GetVillas")]
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if (VillaStore.villaList.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower())!=null);
            {
                ModelState.AddModelError("", "Villa Already Exists!");
                return BadRequest(ModelState);
            }
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDTO.Id = VillaStore.villaList.OrderByDescending(u=>u.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDTO);
            return CreatedAtRoute("GetVillas",new { id =villaDTO.Id},villaDTO);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteVillas")]
        public IActionResult DeleteVilla(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.First(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            VillaStore.villaList.Remove(villa);
            return NoContent();
        }
    }
}
