using Application.Models.MonthlyShipping;
using Application.Services.MonthlyShipping;
using Core.Interfaces.MonthlyShipping;
using NSubstitute;

namespace BookSigningTests.ApplicationTests.Services.MonthlyShipping
{
    public class CreateMonthlyShippingServiceTests
    {
        [Fact]
        public async Task MonthlyShippingValid_CreateNewMonthlyShipping_ReturnTrue()
        {
            //Arrenge
            var monthlyShipping = new MonthlyShippingCreateModel("Os livros deste é sobre...",1,"Marca pagina");
            var repositoryMonthlyShipping = Substitute.For<ICreateMonthlyShippingRepository>();
            var serviceMonthlyShipping = new CreateMonthlyShippingService(repositoryMonthlyShipping);
            repositoryMonthlyShipping.CreateMonthlyShippingAsync(Arg.Any<Core.Entities.MonthlyShipping>()).Returns(1);
            var expected = 1;
            //Act
            var result = await serviceMonthlyShipping.CreateMonthlyShippingAsync(monthlyShipping);
            //Assert
            Assert.Equal(expected, result);
        }
    }
}
