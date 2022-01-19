using DogsHouseService.Interfaces;
using DogsHouseService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace DogsHouseService.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly ApplicationContext _dbContext;

        public DogRepository(ApplicationContext databaseOptions)
        {
            _dbContext = databaseOptions;
        }

        public virtual List<Dog> GetDogs(string attribute, string order, int pageNumber, int pageSize)
        {
            var dogs = _dbContext.Dogs.ToList();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var attributeInfo = textInfo.ToTitleCase(textInfo.ToLower(attribute));
            
            if (dogs.Count > 1 && !String.IsNullOrEmpty(attributeInfo))
            {
                SortDogs(dogs, order, attributeInfo);
            }
            
            var res = dogs.Select(x => new Dog { Id = x.Id, Name = x.Name, Color = x.Color, Length = x.Length, Weight = x.Weight });
            var fulres = res.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            
            return fulres;
        }

        public void SortDogs(List<Dog> dogs, string order, string attribute)
        {
            dogs.Sort((x, y) =>
            {
                var xTcont = x?.GetAttributeWithType(attribute);
                Type xType = xTcont.Value.Item2;
                var xT = Convert.ChangeType(xTcont.Value.Item1, xType);
                var yTcont = y?.GetAttributeWithType(attribute);
                Type yType = yTcont.Value.Item2;
                var yT = Convert.ChangeType(yTcont.Value.Item1, yType);
                if (xT == null)
                {
                    return order == "asc" ? 1 : -1;
                }
                if (yT == null)
                {
                    return order == "asc" ? -1 : 1;
                }
                return order == "asc" ? Comparer.DefaultInvariant.Compare(xT, yT) : Comparer.DefaultInvariant.Compare(yT, xT);
            }
        );
        }


        public virtual void CreateDog(Dog dog)
        {
            _dbContext.Dogs.Add(dog);
            _dbContext.SaveChanges();
        }
    }
}
