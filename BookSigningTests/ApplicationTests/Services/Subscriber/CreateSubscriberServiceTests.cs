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
            var createSubscriberRepository = Substitute.For<ICreateSubscriberRepository>();
            var searchSubscriberRepository = Substitute.For<ISearchSubscriberRepository>();
            var service = new CreateSubscriberService(createSubscriberRepository, searchSubscriberRepository);
            createSubscriberRepository.CreateSubscriberAsync(Arg.Any<Core.Entities.Subscriber>()).Returns(1);
            var expected = 1;

            //Act
            var result = await service.CreateSubscriberAsync(subscriber);

            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void SubscriberNull_CreateNewSubscriber_ReturnExpection()
        {
            //Arrage
            var address = new AddressViewModel();
            SubscriberCreateModel subscriber = null;
            var createSubscriberRepository = Substitute.For<ICreateSubscriberRepository>();
            var searchSubscriberRepository = Substitute.For<ISearchSubscriberRepository>();
            var service = new CreateSubscriberService(createSubscriberRepository, searchSubscriberRepository);
            createSubscriberRepository.CreateSubscriberAsync(Arg.Any<Core.Entities.Subscriber>()).Returns(1);
 
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
            var createSubscriberRepository = Substitute.For<ICreateSubscriberRepository>();
            var searchSubscriberRepository = Substitute.For<ISearchSubscriberRepository>();
            var service = new CreateSubscriberService(createSubscriberRepository, searchSubscriberRepository);
            createSubscriberRepository.CreateSubscriberAsync(Arg.Any<Core.Entities.Subscriber>()).Returns(1);
            var expected = 1;

            //Act
            var result = await service.CreateSubscriberAsync(subscriber);

            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task EmailIsNotSingle_CreateNewSubscriber_ReturnExpection()
        {
            //Arrage
            var address = new AddressViewModel();
            var subscriber = new SubscriberCreateModel("Lucas Silveira", "lucas_silveira@hotmail.com", "(18) 98555-9586", address);
            var subscriberSearching = new Core.Entities.Subscriber("Lucas Silveira Lima", "lucas_silveira@hotmail.com", "(18) 98566-8596", null);
            var createSubscriberRepository = Substitute.For<ICreateSubscriberRepository>();
            var searchSubscriberRepository = Substitute.For<ISearchSubscriberRepository>();
            var service = new CreateSubscriberService(createSubscriberRepository, searchSubscriberRepository);
            createSubscriberRepository.CreateSubscriberAsync(Arg.Any<Core.Entities.Subscriber>()).Returns(1);
            searchSubscriberRepository.GetByEmailAsync(Arg.Any<string>()).Returns(subscriberSearching);
            var expected = 1;

            //Act
            var expection = Assert.ThrowsAsync<Exception>
                (async () => await service.CreateSubscriberAsync(subscriber));

            //Assert
            Assert.Equal("Email is already being used", expection.Result.Message);
        }
    }
}
