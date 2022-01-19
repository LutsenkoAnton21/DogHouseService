using DogsHouseService;
using DogsHouseService.Models;
using DogsHouseService.Repositories;
using DogsHouseService.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DogsHouseServiceTests
{
    public class DogServiceTest
    {
        private Mock<DogRepository> dogRepositoryMock;
        private DogService dogService;
        private List<Dog> dogs;
        
        public DogServiceTest()
        {
            dogs = new List<Dog>
            {
                new Dog { Name = "Anton" }
            };
            var applicationContextMock = new Mock<ApplicationContext>();
            dogRepositoryMock = new Mock<DogRepository>(applicationContextMock.Object);
            dogService = new DogService(dogRepositoryMock.Object);
        }

        [Fact]
        public void GetDogs_ShouldCallDogRepositoryGetDogs()
        {
            // arrange
            dogRepositoryMock.Setup(r => r
                .GetDogs(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));

            // act
            dogService.GetDogs("", "", 1, 1);

            // assert
            dogRepositoryMock.Verify(r => r.GetDogs(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void CreateDog_ShouldAddNewDog()
        {
            // arrange
            var newDog = new Dog { Name = "Sabaka" };
            dogRepositoryMock.Setup(r => r.CreateDog(newDog)).Callback(() => dogs.Add(newDog));

            // act
            dogService.CreateDog(newDog);

            // assert
            Assert.Contains(newDog, dogs);
        }
    }
}
