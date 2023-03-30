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
        public IEnumerable<Pet> GetPets()
        {
            return new List<Pet>();
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


    }
}
