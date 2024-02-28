
using Application.Models.SubscriptionType;
using Application.Services.SubscriptionType;
using Core.Entities;
using Core.Interfaces.SubscriptionType;
using NSubstitute;

namespace BookSigningTests.ApplicationTests.Services
{
    public class CreateSubscriptionTypeServiceTests
    {
        
        [Fact]
        public async Task SubscriptionTypeValid_CreateNewSubscriptionType_ReturnTrue()
        {
            //Arrange
            var subscriptionType = new SubscriptionTypeCreateModel("Primium", "100",100);
            var repository = Substitute.For<ICreateSubscriptionTypeRepository>();
            var service = new CreateSubscriptionTypeService(repository);
            repository.CreateSubscriptionTypeAsync(Arg.Any<SubscriptionType>())
                .Returns(1);
            var expected = 1;

            //Act
            var result = await service.CreateSubscriptionTypeAsync(subscriptionType);
             
            //Assert
            Assert.Equal(result, expected);
        }
        [Fact]
        public async Task SubscriptionTypeInvalid_CreateNewSubscriptionType_ReturnExpection()
        {
            //Arrange
            var subscriptionType = new SubscriptionTypeCreateModel("Primium", "100", -100);
            var repository = Substitute.For<ICreateSubscriptionTypeRepository>();
            var service = new CreateSubscriptionTypeService(repository);
            repository.CreateSubscriptionTypeAsync(Arg.Any<SubscriptionType>())
                .Returns(0);
            
            //Act
            var expection = Assert.ThrowsAsync<Exception>
                (async () => await service.CreateSubscriptionTypeAsync(subscriptionType));

            //Assert
            Assert.Equal("Price is less than zero", expection.Result.Message);
        }
        [Fact]
        public async Task SubscriptionTypeNull_CreateNewSubscriptionType_ReturnExpection()
        {
            //Arrange
            SubscriptionTypeCreateModel subscriptionType = null;
            var repository = Substitute.For<ICreateSubscriptionTypeRepository>();
            var service = new CreateSubscriptionTypeService(repository);
            repository.CreateSubscriptionTypeAsync(Arg.Any<SubscriptionType>())
                .Returns(0);

            //Act
            var expection = Assert.ThrowsAsync<Exception>
                (async () => await service.CreateSubscriptionTypeAsync(subscriptionType));

            //Assert
            Assert.Equal("Subscription Type is null", expection.Result.Message);
        }
    }
}
