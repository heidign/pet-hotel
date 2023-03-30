using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets()
        {
            // return new List<PetOwner>();
            return _context.PetOwners;
        }

        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {
           PetOwner petOwner = _context.PetOwners.SingleOrDefault(p => p.id == id);
            return petOwner;
        }

        [HttpPost]
        public IActionResult Post(PetOwner newPetOwner)
        {
            _context.Add(newPetOwner);
            _context.SaveChanges();

            // return StatusCode(201, newPetOwner);

            return CreatedAtAction(nameof(GetById), new { id = newPetOwner.id }, newPetOwner);
        }

        //! PUT action
        // this method takes in an id and a petOwner object as input parameters
        // the id parameter identifies the particular petOwner record to update
        [HttpPut("{id}")]
        public PetOwner Put(int id, PetOwner petOwner)
        {
            // set the ID property of the petOwner object to match the provided id parameter
            petOwner.id = id;

            // update the changed petOwner record in the database
            _context.Update(petOwner);

            // save the changes to the database
            _context.SaveChanges();

            // return the updated petOwner object
            return petOwner;
        }


        //! DELETE action 
        // this method will handle 'DELETE' requests to the API endpoint with a parameter 'id'
        [HttpDelete("{id}")]
        public ActionResult<PetOwner> Delete(int id)
        {
            // find the record in the database by its ID
            PetOwner petOwner = _context.PetOwners.Find(id);

            // ff record is found, remove the selected PetOwner from the database 
            _context.PetOwners.Remove(petOwner);

            // save the changes made to the database
            _context.SaveChanges();

            // return status code 204 indicating successful deletion of the record
            return StatusCode(204);
        }

    }
}
