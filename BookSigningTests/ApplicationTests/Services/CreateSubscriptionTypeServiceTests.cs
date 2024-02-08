
using Application.Models.SubscriptionType;
using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Moq;

namespace BookSigningTests.ApplicationTests.Services
{
    public class CreateSubscriptionTypeServiceTests
    {
        
        [Fact]
        public async void DeveCriarUmTipoDeAssinatura()
        {
            var subscriptionType = new SubscriptionTypeCreateModel("Primium","Primium Teste", 100);
            var repositoryMock = new Mock<ICreateSubscriptionTypeRepository>();
            var serviceMock = new CreateSubscriptionTypeService(repositoryMock.Object);
            var expected = 1;

            var result = await serviceMock.CreateSubscriptionAsync(subscriptionType);

            Assert.Equal(result, expected);
        }
    }
}
