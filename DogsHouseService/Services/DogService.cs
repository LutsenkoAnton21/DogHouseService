using DogsHouseService.Interfaces;
using DogsHouseService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogsHouseService.Services
{
    public class DogService
    {
        private readonly IDogRepository _dogRepository;

        public DogService(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }


        public List<Dog> GetDogs(string atribute, string order, int pageNumber, int pageSize)
        {
            return _dogRepository.GetDogs(atribute, order, pageNumber, pageSize);
        }

        public void CreateDog(Dog dog)
        {
             _dogRepository.CreateDog(dog);
        }

    }
}
