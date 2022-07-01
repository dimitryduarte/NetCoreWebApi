using Microsoft.EntityFrameworkCore;
using Moq;
using NetCoreWebApi.Models;
using NetCoreWebApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetCoreWebApi.Tests
{
    [Collection("Testing IrrobaOrderRepository of web")]
    public class CustomerRepositoryTest
    {
        public CustomerRepositoryTest() { }

        [Theory]
        [InlineData("Luke")]
        [InlineData("Skywalker")]
        public void Should_Return_Success_GetCustomerByName(string name)
        {
            //Arrange
            var data = new List<Customer> { new Customer { Name = name },
                                            new Customer { Name = name },
                                            new Customer { Name = name } }.AsQueryable();


            var mockSet = new Mock<DbSet<Customer>>();

            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<CustomerContext>();
            mockContext.Setup(x => x.Customer).Returns(mockSet.Object);

            //Act
            var repository = new CustomerRepository(mockContext.Object);
            var customers = repository.GetCustomerByName(name);

            //Assert
            foreach (var customer in customers)
            {
                Assert.NotNull(customer);
                Assert.Equal(name, customer.Name);
                Assert.IsType<Customer>(customer);
            }
        }

        [Theory]
        [InlineData("Ray", "Luke")]
        [InlineData("Palpatine", "Skywalker")]
        public void Should_Return_Error_GetCustomerByName(string expectedName, string name)
        {
            //Arrange
            //Arrange
            var data = new List<Customer> { new Customer { Name = expectedName },
                                            new Customer { Name = expectedName },
                                            new Customer { Name = expectedName } }.AsQueryable();


            var mockSet = new Mock<DbSet<Customer>>();

            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<CustomerContext>();
            mockContext.Setup(x => x.Customer).Returns(mockSet.Object);

            //Act
            var repository = new CustomerRepository(mockContext.Object);
            var customers = repository.GetCustomerByName(name);

            //Assert
            Assert.Empty(customers);

        }
    }

    public class CustomerContext : AppDbContext
    {
        public virtual DbSet<Customer> Customer { get; set; }
    }
}
