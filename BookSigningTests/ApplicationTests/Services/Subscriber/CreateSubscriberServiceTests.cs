using Application.Models.Address;
using Application.Models.Subscriber;
using Application.Services.Subscriber;
using Core.Interfaces.Subscriber;
using NSubstitute;

namespace BookSigningTests.ApplicationTests.Services.Subscriber
{
    public class CreateSubscriberServiceTests
    {
        [Fact]
        public async Task SubscriberValid_CreateNewSubscriber_ReturnTrue()
        {
            //Arrage
            var address = new AddressViewModel();
            var subscriber = new SubscriberCreateModel("Lucas Silveira", "lucas_silveira", "(18) 98555-9586",address);
            var repository = Substitute.For<ICreateSubscriberRepository>();
            var service = new CreateSubscriberService(repository);
            repository.CreateSubscriberAsync(Arg.Any<Core.Entities.Subscriber>()).Returns(1);
            var expected = 1;

            //Act
            var result = await service.CreateSubscriberAsync(subscriber);

            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void SubscriberNull_CreateNewSubscriber_ReturnTrue()
        {
            //Arrage
            var address = new AddressViewModel();
            SubscriberCreateModel subscriber = null;
            var repository = Substitute.For<ICreateSubscriberRepository>();
            var service = new CreateSubscriberService(repository);
            repository.CreateSubscriberAsync(Arg.Any<Core.Entities.Subscriber>()).Returns(1);
 
            //Act
            var expection = Assert.ThrowsAsync<Exception>
                (async () => await service.CreateSubscriberAsync(subscriber));

            //Assert
            Assert.Equal("Subscriber is null", expection.Result.Message);
        }
        [Fact]
        public async Task EmailIsSingle_CreateNewSubscriber_ReturnTrue()
        {
            //Arrage
            var address = new AddressViewModel();
            var subscriber = new SubscriberCreateModel("Lucas Silveira", "lucas_silveira", "(18) 98555-9586", address);
            var repository = Substitute.For<ICreateSubscriberRepository>();
            var service = new CreateSubscriberService(repository);
            repository.CreateSubscriberAsync(Arg.Any<Core.Entities.Subscriber>()).Returns(1);
            var expected = 1;

            //Act
            var result = await service.CreateSubscriberAsync(subscriber);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
