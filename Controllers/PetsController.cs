using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.Pets.Include(pet => pet.petOwner);
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id, Pet pet) {
             _context.Pets.SingleOrDefault(p => p.id == id);
             return pet;
        }
        
    //! DELETE action
    //Delete api/pets
        // this method handles 'DELETE' requests to the API endpoint with a parameter 'id'
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            // find the record in the database by its ID
            Pet pet = _context.Pets.Find(id);
        
            // if record is found, remove the selected pet from the database 
            _context.Pets.Remove(pet);
        
            // save the changes made to the database
            _context.SaveChanges();
        
            // return status code 204 indicating successful deletion of the record
            return StatusCode(204);
        }
        
        // [HttpGet]
        // [Route("api/[controller]")]
        // public IEnumerable<Pet> GetPets()
        // {
        //     PetOwner blaine = new PetOwner
        //     {
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet
        //     {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet
        //     {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet> { newPet1, newPet2 };
        // }

        // * Put by id * //
        [HttpPut("{id}")]
        public IActionResult UpdatePet(int id, Pet pet)
        {
            pet.id = id;

            // update db context with pet id
            _context.Update(pet);

            //  save changes to object in db
            _context.SaveChanges();

            //  return pet object
            return Ok(pet);
        }

        // * Put check in * //
        [HttpPut("{id}/checkin")]

        public IActionResult PutCheckIn(int id)
        {
            Console.WriteLine("test");

            Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == id);

            pet.checkedInAt = DateTime.Now;

            _context.Update(pet);

            // save changes to pet object in db
            _context.SaveChanges();

            // return response from pet object 
            return Ok(pet);
        }

        // * Put check out * //
        [HttpPut("{id}/checkout")]
        
        public IActionResult PutCheckOut(int id)
        {
            Console.WriteLine("test");

            Pet pet = _context.Pets.Find(id);

            pet.checkedInAt = null;

            _context.Update(pet);

            // save changes to db
            _context.SaveChanges();

            return Ok(pet);
        }
        [HttpPost]
        public Pet Post(Pet newPet) {
            _context.Add(newPet);
            _context.SaveChanges();
            
            return newPet;
        }



    //! PUT action
       // this method takes in an id and a pet object as input parameters
       // the id parameter identifies the specific pet record to update
       [HttpPut("{id}")]
       public Pet Put(int id, Pet pet)
       {
           // set the ID property of the pet object to match the provided id parameter
           pet.id = id;
       
           // update the changed pet record in the database
           _context.Update(pet);
       
           // save the changes to the database
           _context.SaveChanges();
       
           // return the updated pet object
           return pet;
       }
       

    }
}
