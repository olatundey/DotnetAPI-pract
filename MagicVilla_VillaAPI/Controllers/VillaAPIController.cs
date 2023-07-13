using System;
using System.ComponentModel.DataAnnotations;
using MagicVilla_VillaAPI.Data;
//using MagicVilla_VillaAPI.Logging;
using MagicVilla_VillaAPI.Model;
using MagicVilla_VillaAPI.Model.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Controllers
{
    // [Route("api/[controller]")]  
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogger<VillaAPIController> _logger;
        private readonly ApplicationDbContext _db;

        //adding logger
        public VillaAPIController(ILogger<VillaAPIController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        //for console windo w logging
        //private readonly ILogging _logger;
        //public VillaAPIController(ILogging logger)
        //{
        //    _logger = logger;
        //}


        //create an Endpoint

        //IEnumerable is best to query data
        //from in-memory collections like List,
        //Array etc.IEnumerable doesn't support
        //add or remove items from the list.

        //Using IEnumerable we can find out the
        //no of elements in the collection after
        //iterating the collection.

        // List can store elements of different
        // types, but arrays can
        // store elements only of the same type.
        //List [], Array ([])
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        //public IEnumerable<VillaDTO> GetVillas()
        {
            //_logger.Log("Getting all villas","");
            _logger.LogInformation("Getting all villas");
            //return VillaStore.VillaList;
            //return Ok(VillaStore.VillaList);
            return Ok(_db.Villas.ToList());
        }
        //public String Villa { }
        //there are string public their name

        //[HttpGet("id")]
        //[HttpGet("{id:int}")]
        [HttpGet("{id:int}", Name = "GetVilla")] //give it an explicit name
        //[ProducesResponseType(200, Type = typeof(VillaDTO)]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            //add validations & status codes
            if (id == 0)
            {
                //_logger.Log("Get Villa Error with Id" + id, "");
                _logger.LogError("Get Villa Error with Id" + id);
                return BadRequest();
            }
            //var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);

            //id that doesnt exist
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
            //return Ok(VillaStore.VillaList.FirstOrDefault(u => u.Id == id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            //check if empty name
            //if (ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //check if name already exist
            if (_db.Villas.FirstOrDefault(u => u.Name.ToLower()
            == villaDTO.Name.ToLower()) != null)
            {
                //ModelState.AddModelError("", "Villa already Exists!");
                ModelState.AddModelError("CustomError", "Villa already Exists!");
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
            //villaDTO.Id =
            //    VillaStore.VillaList.OrderByDescending
            //    (u => u.Id).FirstOrDefault().Id + 1;
            //VillaStore.VillaList.Add(villaDTO);
            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Sqft = villaDTO.Sqft,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                ImageUrl = villaDTO.ImageUrl
            };
            _db.Villas.Add(model);
            _db.SaveChanges();

            //return Ok(villaDTO);
            //For checking ID recently created, route itself
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
            //need to give GetVilla an explicit name

        }

        //DELETE BY ID
        [HttpDelete("{id:int}", Name = "DeleteVilla ")]
        //response type
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            //var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
            //id that doesnt exist
            if (villa == null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
            //VillaStore.VillaList.Remove(villa);
            return NoContent();
        }


        [HttpPut] //update
        //response type
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            //if (id == 0)
            //{
            //    return BadRequest();
            //}
            //id that doesnt exist
            if (villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }
            //var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
            //ind the first user in the collection whose Id property
            //matches the provided id.
            //villa.Name = villaDTO.Name;
            //villa.Sqft = villaDTO.Sqft;
            //villa.Occupancy = villaDTO.Occupancy;
            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Sqft = villaDTO.Sqft,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                ImageUrl = villaDTO.ImageUrl
            };
            _db.Villas.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        //update only one property like name
        //[HttpPatch] - CHECK SITE CALLED - JSONPATCH.COM
        //add 2 nuget patch - MS.jsonpatch & NewtonSoft.json
        //add NewtonSoft.json as the controller service in the app program
        //so support is given to the service...

        [HttpPatch("{id:int}", Name = "UpdatPartialVilla ")]
        //response type
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            //var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            var villa = _db.Villas.AsNoTracking().FirstOrDefault(u => u.Id == id);
            //as no tracking cos of model id already beeing tracked

            //var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
            //id that doesnt exist

            //test here by debugging,  cos of error with model id tracking
            //villa.Name = "new name";
            //_db.SaveChanges();

            VillaDTO villaDTO = new()
            {
                Amenity = villa.Amenity,
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                ImageUrl = villa.ImageUrl
            };

            if (villa == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villaDTO, ModelState);
            //CONVERT BACK TO VILLA BEFORE IT CAN BE UPDATED
            Villa model = new Villa()
            {
                Amenity = villaDTO.Amenity,
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Sqft = villaDTO.Sqft,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                ImageUrl = villaDTO.ImageUrl
            };
            _db.Villas.Update(model);
            _db.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
       
            return NoContent();

            //in swagger from JsonPatch.com
            //we need to add in body for below 3
            //path of what we need to change
            //op - replace
            //value: "new villa 2"
        }

    }
}

