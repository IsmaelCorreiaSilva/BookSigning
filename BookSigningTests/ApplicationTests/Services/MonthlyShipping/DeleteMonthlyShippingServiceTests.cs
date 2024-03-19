
using Application.Models.MonthlyShipping;
using Application.Services.MonthlyShipping;
using Core.Interfaces.MonthlyShipping;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace BookSigningTests.ApplicationTests.Services.MonthlyShipping
{
    public class DeleteMonthlyShippingServiceTests
    {
        [Fact]
        public async Task IdValid_DeleteMonthlyShipping_ReturnTrue()
        {
            //Arrage
            var id = 1;
            var monthlyShipping = new MonthlyShippingCreateModel("Os livros deste é sobre...", null, "Marca pagina");
            var repositoryDelete = Substitute.For<IDeleteMonthlyShippingRepository>();
            var repositorySearch = Substitute.For<ISearchMonthlyShippingRepository>();
            var service = new DeleteMonthlyShippingService(repositoryDelete, repositorySearch);
            repositorySearch.GetByIdAsync(Arg.Any<int>()).Returns(monthlyShipping.ToEntity());
            repositoryDelete.DeleteByIdAsync(Arg.Any<int>()).Returns(1);
            var expected = 1;
            //Act
            var result = await service.DeleteByIdAsync(id);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task IdInvalid_DeleteMonthlyShipping_ReturnExpection()
        {
            //Arrage
            var id = -1;
            var repositoryDelete = Substitute.For<IDeleteMonthlyShippingRepository>();
            var repositorySearch = Substitute.For<ISearchMonthlyShippingRepository>();
            var service = new DeleteMonthlyShippingService(repositoryDelete, repositorySearch);

            //Act
            var exception = Assert.ThrowsAsync<Exception>
                (async () => await service.DeleteByIdAsync(id));
            //Assert
            Assert.Equal("Invalid ID", exception.Result.Message);
        }
        [Fact]
        public async Task MonthlyShippingDoesNotExist_DeleteSubscriptionType_ReturnExpection()
        {
            //Arrage
            var id = 55;
            var repositoryDelete = Substitute.For<IDeleteMonthlyShippingRepository>();
            var repositorySearch = Substitute.For<ISearchMonthlyShippingRepository>();
            var service = new DeleteMonthlyShippingService(repositoryDelete, repositorySearch);
            repositorySearch.GetByIdAsync(Arg.Any<int>()).ReturnsNull();
            //Act
            var exception = Assert.ThrowsAsync<Exception>
                (async () => await service.DeleteByIdAsync(id));
            //Assert
            Assert.Equal("Monthly Shipping does not exist", exception.Result.Message);
        }
    }
}
