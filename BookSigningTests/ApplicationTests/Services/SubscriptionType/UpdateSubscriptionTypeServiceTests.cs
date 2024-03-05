
using Application.Models.SubscriptionType;
using Application.Services.SubscriptionType;
using Core.Entities;
using Core.Interfaces.SubscriptionType;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace BookSigningTests.ApplicationTests.Services.SubscriptionType
{
    public class UpdateSubscriptionTypeServiceTests
    {
        [Fact]
        public async Task SubscriptionTypeValid_UpdateSubscription_ReturnTrue()
        {
            //Arrange
            var subscriptionType = new SubscriptionTypeUpdateModel(1, "Primium", "100", 100);
            var repositoryUpdate = Substitute.For<IUpdateSubscriptionTypeRepository>();
            var repositorySearch = Substitute.For<ISearchSubscriptionTypeRepository>();
            var service = new UptadeSubscriptionTypeService(repositoryUpdate, repositorySearch);
            repositorySearch.GetByIdAsync(Arg.Any<int>())
                .Returns(subscriptionType.ToEntity());
            repositoryUpdate.UpdateSubscriptionTypeAsync(Arg.Any<Core.Entities.SubscriptionType>())
                .Returns(1);
            var expected = 1;

            //Act
            var result = await service.UpdateSubscriptionTypeAsync(subscriptionType);

            //Assert
            Assert.Equal(result, expected);
        }
        [Fact]
        public async Task SubscriptionTypeInvalid_UpdateSubscription_ReturnException()
        {
            //Arrange
            var subscriptionType = new SubscriptionTypeUpdateModel(1, "Primium", "100", -100);
            var repositoryUpdate = Substitute.For<IUpdateSubscriptionTypeRepository>();
            var repositorySearch = Substitute.For<ISearchSubscriptionTypeRepository>();
            var service = new UptadeSubscriptionTypeService(repositoryUpdate, repositorySearch);
            repositorySearch.GetByIdAsync(Arg.Any<int>())
                .Returns(subscriptionType.ToEntity());
            repositoryUpdate.UpdateSubscriptionTypeAsync(Arg.Any<Core.Entities.SubscriptionType>())
                .Returns(0);
            var expected = 0;

            //Act
            var expection = Assert.ThrowsAsync<Exception>
                (async () => await service.UpdateSubscriptionTypeAsync(subscriptionType));

            //Assert
            Assert.Equal("Price is less than zero", expection.Result.Message);
        }
        [Fact]
        public async Task SubscriptionTypeNull_UpdateSubscription_ReturnException()
        {
            //Arrange
            SubscriptionTypeUpdateModel subscriptionType = null;
            //var subscriptionTypeEntity = new SubscriptionType(1, "Primium", "Oferta de livro", 100);
            var repositoryUpdate = Substitute.For<IUpdateSubscriptionTypeRepository>();
            var repositorySearch = Substitute.For<ISearchSubscriptionTypeRepository>();
            var service = new UptadeSubscriptionTypeService(repositoryUpdate, repositorySearch);
            repositorySearch.GetByIdAsync(Arg.Any<int>())
                .ReturnsNull();
            repositoryUpdate.UpdateSubscriptionTypeAsync(Arg.Any<Core.Entities.SubscriptionType>())
                .Returns(0);
            var expected = 0;

            //Act
            var expection = Assert.ThrowsAsync<Exception>
                (async () => await service.UpdateSubscriptionTypeAsync(subscriptionType));

            //Assert
            Assert.Equal("Subscription Type is null", expection.Result.Message);
        }
        [Fact]
        public async Task SubscriptionTypeDoesNotExist_UpdateSubscription_ReturnException()
        {
            //Arrange
            var subscriptionType = new SubscriptionTypeUpdateModel(1, "Primium", "100", 100);
            var repositoryUpdate = Substitute.For<IUpdateSubscriptionTypeRepository>();
            var repositorySearch = Substitute.For<ISearchSubscriptionTypeRepository>();
            var service = new UptadeSubscriptionTypeService(repositoryUpdate, repositorySearch);
            repositorySearch.GetByIdAsync(Arg.Any<int>()).ReturnsNull();
            repositoryUpdate.UpdateSubscriptionTypeAsync(Arg.Any<Core.Entities.SubscriptionType>())
                .Returns(0);

            //Act
            var expection = Assert.ThrowsAsync<Exception>
                (async () => await service.UpdateSubscriptionTypeAsync(subscriptionType));

            //Assert
            Assert.Equal("Subscription Type does not exist", expection.Result.Message);
        }
    }
}
