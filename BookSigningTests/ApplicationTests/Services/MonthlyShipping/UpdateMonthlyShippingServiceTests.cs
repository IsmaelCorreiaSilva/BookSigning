
using Application.Models.Book;
using Application.Models.MonthlyShipping;
using Application.Services.MonthlyShipping;
using Core.Entities;
using Core.Interfaces.Book;
using Core.Interfaces.MonthlyShipping;
using NSubstitute;

namespace BookSigningTests.ApplicationTests.Services.MonthlyShipping
{
    public class UpdateMonthlyShippingServiceTests
    {
        [Fact]
        public async Task MonthlyShippingValid_UpdateMonthlyShipping_ReturnTrue()
        {
            //Arrenge
            var books = new List<BookItemModel>();
            books.Add(new BookItemModel(1));
            books.Add(new BookItemModel(2));
            var monthlyShipping = new MonthlyShippingUpdateModel(1,"Os livros deste é sobre...", books, "Marca pagina");
            var repositoryMonthlyShipping = Substitute.For<IUpdateMonthlyShippingRepository>();
            var repositorySearchBook = Substitute.For<ISearchBookRepository>();
            var serviceMonthlyShipping = new UpdateMonthlyShippingService(repositoryMonthlyShipping, repositorySearchBook);
            repositoryMonthlyShipping.UpdateMonthlyShippingAsync(Arg.Any<Core.Entities.MonthlyShipping>()).Returns(1);
            var expected = 1;
            //Act
            var result = await serviceMonthlyShipping.UpdateMonthlyShippingAsync(monthlyShipping);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task MonthlyShippingNull_UpdateMonthlyShipping_ReturnExpection()
        {
            //Arrenge
            
            MonthlyShippingUpdateModel monthlyShipping = null;
            var repositoryMonthlyShipping = Substitute.For<IUpdateMonthlyShippingRepository>();
            var repositorySearchBook = Substitute.For<ISearchBookRepository>();
            var serviceMonthlyShipping = new UpdateMonthlyShippingService(repositoryMonthlyShipping, repositorySearchBook);
                       
            //Act
            var expection = Assert.ThrowsAsync<Exception> (
                async () => await serviceMonthlyShipping.UpdateMonthlyShippingAsync(monthlyShipping));
            //Assert
            Assert.Equal("Monthly Shipping is null", expection.Result.Message);
        }
        [Fact]
        public async Task OneOrMoreBook_UpdateMonthlyShipping_ReturnTrue()
        {
            //Arrenge
            var books = new List<BookItemModel>();
            books.Add(new BookItemModel(1));
            books.Add(new BookItemModel(2));
            var monthlyShipping = new MonthlyShippingUpdateModel(1, "Os livros deste é sobre...", books, "Marca pagina");
            var repositoryMonthlyShipping = Substitute.For<IUpdateMonthlyShippingRepository>();
            var repositorySearchBook = Substitute.For<ISearchBookRepository>();
            var serviceMonthlyShipping = new UpdateMonthlyShippingService(repositoryMonthlyShipping, repositorySearchBook);
            repositoryMonthlyShipping.UpdateMonthlyShippingAsync(Arg.Any<Core.Entities.MonthlyShipping>()).Returns(1);
            var expected = 1;
            //Act
            var result = await serviceMonthlyShipping.UpdateMonthlyShippingAsync(monthlyShipping);
            //Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task NumberOfBooksLessThanOne_UpdateMonthlyShipping_ReturnTrue()
        {
            //Arrenge
            var books = new List<BookItemModel>();
            var monthlyShipping = new MonthlyShippingUpdateModel(1, "Os livros deste é sobre...", books, "Marca pagina");
            var repositoryMonthlyShipping = Substitute.For<IUpdateMonthlyShippingRepository>();
            var repositorySearchBook = Substitute.For<ISearchBookRepository>();
            var serviceMonthlyShipping = new UpdateMonthlyShippingService(repositoryMonthlyShipping, repositorySearchBook);
            repositoryMonthlyShipping.UpdateMonthlyShippingAsync(Arg.Any<Core.Entities.MonthlyShipping>()).Returns(1);
            
            //Act
            var expection = Assert.ThrowsAsync<Exception>
                ( async () => await serviceMonthlyShipping.UpdateMonthlyShippingAsync(monthlyShipping));
            //Assert
            Assert.Equal("Doesn't have books", expection.Result.Message);
        }
        [Fact]
        public async Task IdInvalid_UpdateMonthlyShipping_ReturnTrue()
        {
            //Arrenge
            var books = new List<BookItemModel>();
            var monthlyShipping = new MonthlyShippingUpdateModel(-22, "Os livros deste é sobre...", books, "Marca pagina");
            var repositoryMonthlyShipping = Substitute.For<IUpdateMonthlyShippingRepository>();
            var repositorySearchBook = Substitute.For<ISearchBookRepository>();
            var serviceMonthlyShipping = new UpdateMonthlyShippingService(repositoryMonthlyShipping, repositorySearchBook);
            repositoryMonthlyShipping.UpdateMonthlyShippingAsync(Arg.Any<Core.Entities.MonthlyShipping>()).Returns(1);

            //Act
            var expection = Assert.ThrowsAsync<Exception>
                (async () => await serviceMonthlyShipping.UpdateMonthlyShippingAsync(monthlyShipping));
            //Assert
            Assert.Equal("Id is invalid", expection.Result.Message);
        }
    }
}
