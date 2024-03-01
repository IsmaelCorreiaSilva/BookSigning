
using Application.Models.SubscriptionType;
using Application.Services.SubscriptionType;
using Core.Entities;
using Core.Interfaces.SubscriptionType;
using NSubstitute;

namespace BookSigningTests.ApplicationTests.Services
{
    public class DeleteSubscriptionTypeServiceTests
    {
        [Fact]
        public async Task IdValid_DeleteSubscriptionType_ReturnTrue()
        {
            //Arrange
            var id = 1;
            var repository = Substitute.For<IDeleteSubscriptionTypeRepository>();
            var service = new DeleteSubscriptionTypeService(repository);
            repository.DeleteByIdAsync(Arg.Any<int>())
                .Returns(1);
            var expected = 1;

            //Act
            var result = await service.DeleteByIdAsync(id);

            //Assert
            Assert.Equal(result, expected);
        }
    }
}
