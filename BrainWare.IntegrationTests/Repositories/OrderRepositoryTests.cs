using BrainWare.Dal;
using BrainWare.Dal.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BrainWare.IntegrationTests.Repositories
{
    [TestFixture]
    public class OrderRepositoryTests
    {

        
        [Test]
        public void GetCompanyOrders_ShouldReturnACollectionOfOrders_ThatMatchTheCompanyId()
        {
            // Arrange
            var sut = new OrderRepository();

            // Act
            var result = sut.GetCompanyOrders(1);

            // Assert
            result.Should().SatisfyRespectively(order1 => 
                {
                    order1.OrderId.Should().Be(1);
                    order1.CompanyName.Should().Be("Company 1");
                    order1.Description.Should().Be("Order 1");
                },
                order2 => 
                {
                    order2.OrderId.Should().Be(1);
                    order2.CompanyName.Should().Be("Company 1");
                    order2.Description.Should().Be("Order 2");
                }
                );
        }
    }
}