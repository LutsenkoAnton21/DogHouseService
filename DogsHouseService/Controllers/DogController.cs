using DogsHouseService.Models;
using DogsHouseService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DogsHouseService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : ControllerBase
    {
        private readonly DogService _dogService;
        private readonly ApplicationContext _dbContext;
        
        public DogController(DogService dogService, ApplicationContext dbContext)
        {
            _dogService = dogService;
            _dbContext = dbContext;
    }

        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            System.Threading.Thread.Sleep(1000);
            string message = "Dogs house service. Version 1.0.1";
            return Ok(message);
        }

        [HttpGet("Dogs")]
        public IActionResult GetDogs(string attribute = "", string order = "asc", int pageNumber = 1, int pageSize = 3)
        {
            System.Threading.Thread.Sleep(1000);
            var result = _dogService.GetDogs(attribute, order, pageNumber, pageSize);
            return Ok(result);
        }


        [HttpPost("Dog")]
        public IActionResult CreateDog(DogModel model)
        {
            System.Threading.Thread.Sleep(1000);

            Dog dog = new Dog { Name = model.Name, Color = model.Color, Length = model.Length, Weight = model.Weight };

            var qwerty = _dbContext.Dogs.FirstOrDefault(q => q.Name == dog.Name);
            if (qwerty != null)
            {
                ModelState.AddModelError("Name", "Dog with the same name already exists");
                return BadRequest(ModelState);
            }

            _dogService.CreateDog(dog);
            return Ok(model);
        }
    }
}
