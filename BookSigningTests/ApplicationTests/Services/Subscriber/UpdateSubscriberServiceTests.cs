
using Application.Models.Address;
using Application.Models.Subscriber;
using Application.Services.Subscriber;
using Core.Interfaces.Subscriber;
using NSubstitute;

namespace BookSigningTests.ApplicationTests.Services.Subscriber
{
    public class UpdateSubscriberServiceTests
    {
        [Fact]
        public async Task SubscriberValid_UpdateSubscriber_ReturnTrue()
        {
            //Arrange
            var address = new AddressViewModel();
            var subscriber = new SubscriberUpdateModel(1,"Lucas Silveira", "lucas_silveira", "(18) 98555-9586", address); 
            var updateSubscriberRepository = Substitute.For<IUpdateSubscriberRepository>();
            var searchSubscriberRepository = Substitute.For<ISearchSubscriberRepository>();
            var updateSubscriberService = new UpdateSubscriberService(updateSubscriberRepository, searchSubscriberRepository);
            updateSubscriberRepository.UpdateSubscriberAsync(Arg.Any<Core.Entities.Subscriber>()).Returns(1);
            var expected = 1;
            //Act
            var result = await updateSubscriberService.UpdateSubscriberAsync(subscriber);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task SubscriberNull_UpdateSubscriber_ReturnExpection()
        {
            //Arrange
            SubscriberUpdateModel subscriber = null;
            var updateSubscriberRepository = Substitute.For<IUpdateSubscriberRepository>();
            var searchSubscriberRepository = Substitute.For<ISearchSubscriberRepository>();
            var updateSubscriberService = new UpdateSubscriberService(updateSubscriberRepository, searchSubscriberRepository);
            
            //Act
            var expection = Assert.ThrowsAsync<Exception>
                (async () => await updateSubscriberService.UpdateSubscriberAsync(subscriber));
            //Assert
            Assert.Equal("Subscriber is null", expection.Result.Message);
        }
        [Fact]
        public async Task EmaelIsSingle_UpdateSubscriber_ReturnTrue()
        {
            //Arrange
            var address = new AddressViewModel();
            var subscriber = new SubscriberUpdateModel(1, "Lucas Silveira", "lucas_silveira@hotmail.com", "(18) 98555-9586", address);
            var updateSubscriberRepository = Substitute.For<IUpdateSubscriberRepository>();
            var searchSubscriberRepository = Substitute.For<ISearchSubscriberRepository>();
            var updateSubscriberService = new UpdateSubscriberService(updateSubscriberRepository, searchSubscriberRepository);
            updateSubscriberRepository.UpdateSubscriberAsync(Arg.Any<Core.Entities.Subscriber>()).Returns(1);
            var expected = 1;
            //Act
            var result = await updateSubscriberService.UpdateSubscriberAsync(subscriber);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task EmaelIsNotSingle_UpdateSubscriber_ReturnException()
        {
            //Arrange
            var address = new AddressViewModel();
            var subscriber = new SubscriberUpdateModel(1, "Lucas Silveira", "lucas_silveira@hotmail.com", "(18) 98555-9586", address);
            var subscriberSearching = new Core.Entities.Subscriber("Lucas Silveira Lima", "lucas_silveira@hotmail.com", "(18) 98566-8596", null);
            var updateSubscriberRepository = Substitute.For<IUpdateSubscriberRepository>();
            var searchSubscriberRepository = Substitute.For<ISearchSubscriberRepository>();
            var updateSubscriberService = new UpdateSubscriberService(updateSubscriberRepository, searchSubscriberRepository);
            updateSubscriberRepository.UpdateSubscriberAsync(Arg.Any<Core.Entities.Subscriber>()).Returns(1);
            searchSubscriberRepository.GetByEmailAsync(Arg.Any<string>()).Returns(subscriberSearching);
            var expected = 1;
            //Act
            var exception = Assert.ThrowsAsync<Exception>
                ( async () => await updateSubscriberService.UpdateSubscriberAsync(subscriber));
            //Assert
            Assert.Equal("Email is already being used", exception.Result.Message);
        }
    }
}
