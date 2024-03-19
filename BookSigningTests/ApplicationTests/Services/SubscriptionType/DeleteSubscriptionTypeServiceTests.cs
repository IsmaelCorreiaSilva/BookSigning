
using Application.Models.SubscriptionType;
using Application.Services.SubscriptionType;
using Core.Entities;
using Core.Interfaces.SubscriptionType;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace BookSigningTests.ApplicationTests.Services.SubscriptionType
{
    public class DeleteSubscriptionTypeServiceTests
    {
        [Fact]
        public async Task IdValid_DeleteSubscriptionType_ReturnTrue()
        {
            //Arrange
            var id = 1;
            var subscriptionType = new Core.Entities.SubscriptionType(1, "Premium", "Teste", 100);
            var repositoryDelete = Substitute.For<IDeleteSubscriptionTypeRepository>();
            var repositorySearch = Substitute.For<ISearchSubscriptionTypeRepository>();
            var service = new DeleteSubscriptionTypeService(repositoryDelete, repositorySearch);
            repositoryDelete.DeleteByIdAsync(Arg.Any<int>())
                .Returns(1);
            repositorySearch.GetByIdAsync(Arg.Any<int>()).Returns(subscriptionType);
            var expected = 1;

            //Act
            var result = await service.DeleteByIdAsync(id);

            //Assert
            Assert.Equal(result, expected);
        }
        [Fact]
        public async Task IdInvalid_DeleteSubscriptionType_ReturnExpection()
        {
            //Arrange
            var id = -1;
            var repositoryDelete = Substitute.For<IDeleteSubscriptionTypeRepository>();
            var repositorySearch = Substitute.For<ISearchSubscriptionTypeRepository>();
            var service = new DeleteSubscriptionTypeService(repositoryDelete, repositorySearch);
          
            //Act
            var exception = Assert.ThrowsAsync<Exception>(
                async () => await service.DeleteByIdAsync(id));

            //Assert
            Assert.Equal("Invalid ID", exception.Result.Message);
        }
        [Fact]
        public async Task SubscriptionTypeDoesNotExist_DeleteSubscriptionType_ReturnExpection()
        {
            //Arrange
            var id = 55;
            var repositoryDelete = Substitute.For<IDeleteSubscriptionTypeRepository>();
            var repositorySearch = Substitute.For<ISearchSubscriptionTypeRepository>();
            var service = new DeleteSubscriptionTypeService(repositoryDelete, repositorySearch);
            //repositoryDelete.DeleteByIdAsync(Arg.Any<int>())
            //    .Returns(1);
            repositorySearch.GetByIdAsync(Arg.Any<int>()).ReturnsNull();


            //Act
            var exception = Assert.ThrowsAsync<Exception>(
                async () => await service.DeleteByIdAsync(id));

            //Assert
            Assert.Equal("Subscription Type does not exist", exception.Result.Message);
        }
    }
}
