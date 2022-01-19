using DogsHouseService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogsHouseService.Interfaces
{
    public interface IDogRepository
    {
        void CreateDog(Dog dog);
        List<Dog> GetDogs(string attribute, string order, int pageNumber, int pageSize);
    }
}
