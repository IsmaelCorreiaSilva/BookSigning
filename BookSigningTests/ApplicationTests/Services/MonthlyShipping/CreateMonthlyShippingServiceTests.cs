using Application.Models.Book;
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
            var monthlyShipping = new MonthlyShippingCreateModel("Os livros deste é sobre...",null,"Marca pagina");
            var repositoryMonthlyShipping = Substitute.For<ICreateMonthlyShippingRepository>();
            var serviceMonthlyShipping = new CreateMonthlyShippingService(repositoryMonthlyShipping);
            repositoryMonthlyShipping.CreateMonthlyShippingAsync(Arg.Any<Core.Entities.MonthlyShipping>()).Returns(1);
            var expected = 1;
            //Act
            var result = await serviceMonthlyShipping.CreateMonthlyShippingAsync(monthlyShipping);
            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task MonthlyShippingNull_CreateNewMonthlyShipping_ReturnExpection()
        {
            //Arrenge
            MonthlyShippingCreateModel monthlyShipping = null;
            var repositoryMonthlyShipping = Substitute.For<ICreateMonthlyShippingRepository>();
            var serviceMonthlyShipping = new CreateMonthlyShippingService(repositoryMonthlyShipping);
            
            //Act
            var expection = Assert.ThrowsAsync<Exception>
                ( async () => await serviceMonthlyShipping.CreateMonthlyShippingAsync(monthlyShipping));
            //Assert
            Assert.Equal("Monthly Shipping is null", expection.Result.Message);
        }
        [Fact]
        public async Task OneOrMoreBook_CreateNewMonthlyShipping_ReturnTrue()
        {
            //Arrenge
            var monthlyShipping = new MonthlyShippingCreateModel("Os livros deste é sobre...", null, "Marca pagina");
            var repositoryMonthlyShipping = Substitute.For<ICreateMonthlyShippingRepository>();
            var serviceMonthlyShipping = new CreateMonthlyShippingService(repositoryMonthlyShipping);
            repositoryMonthlyShipping.CreateMonthlyShippingAsync(Arg.Any<Core.Entities.MonthlyShipping>()).Returns(1);
            var expected = 1;

            //Act
            var result = await serviceMonthlyShipping.CreateMonthlyShippingAsync(monthlyShipping);
            //Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public async Task NumberOfBooksLessThanOne_CreateNewMonthlyShipping_ReturnExpection()
        {
            //Arrenge
            var books = new List<BookItemModel>();
            books.Add(new BookItemModel(1));
            books.Add(new BookItemModel(2));
            var monthlyShipping = new MonthlyShippingCreateModel("Os livros deste é sobre...", books, "Marca pagina");
            var repositoryMonthlyShipping = Substitute.For<ICreateMonthlyShippingRepository>();
            var serviceMonthlyShipping = new CreateMonthlyShippingService(repositoryMonthlyShipping);
            //repositoryMonthlyShipping.CreateMonthlyShippingAsync(Arg.Any<Core.Entities.MonthlyShipping>()).Returns(1);

            //Act
            var expection = Assert.ThrowsAsync<Exception>
                (async () => await serviceMonthlyShipping.CreateMonthlyShippingAsync(monthlyShipping));
            //Assert
            Assert.Equal("Doesn't have books", expection.Result.Message);
        }
    }
}
