
using Application.Services.Subscriber;
using Core.Interfaces.Subscriber;
using NSubstitute;

namespace BookSigningTests.ApplicationTests.Services.Subscriber
{
    public class DeleteSubscriberServiceTests
    {
        [Fact]
        public async Task IdValid_DeleteSubscriber_ReturnTrue()
        {
            //Arrage
            var id = 1;
            var deleteSubscriberRepository = Substitute.For<IDeleteSubscriberRepository>();
            var searchSubscriberRepository = Substitute.For<ISearchSubscriberRepository>();
            var deleteSubscriberService = new DeleteSubscriberService(deleteSubscriberRepository, searchSubscriberRepository);
            deleteSubscriberRepository.DeleteByIdAsync(Arg.Any<int>()).Returns(1);
            var expected = 1;
            //Act
            var result = await deleteSubscriberRepository.DeleteByIdAsync(id);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task IdInvalid_DeleteSubscriber_ReturnException()
        {
            //Arrage
            var id = -11;
            var deleteSubscriberRepository = Substitute.For<IDeleteSubscriberRepository>();
            var searchSubscriberRepository = Substitute.For<ISearchSubscriberRepository>();
            var deleteSubscriberService = new DeleteSubscriberService(deleteSubscriberRepository, searchSubscriberRepository);
            //Act
            var exception = Assert.ThrowsAsync<Exception>
                (async () => await deleteSubscriberService.DeleteByIdAsync(id));
            //Assert
            Assert.Equal("Invalid ID", exception.Result.Message);
        }
        [Fact]
        public async Task SubscriberDoesNotExist_DeleteSubscriber_ReturnException()
        {
            //Arrage
            var id = 60;
            var deleteSubscriberRepository = Substitute.For<IDeleteSubscriberRepository>();
            var searchSubscriberRepository = Substitute.For<ISearchSubscriberRepository>();
            var deleteSubscriberService = new DeleteSubscriberService(deleteSubscriberRepository, searchSubscriberRepository);
            //Act
            var exception = Assert.ThrowsAsync<Exception>
                (async () => await deleteSubscriberService.DeleteByIdAsync(id));
            //Assert
            Assert.Equal("Subscriber does not exist", exception.Result.Message);
        }
    }
}
