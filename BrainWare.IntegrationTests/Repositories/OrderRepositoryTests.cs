using BrainWare.Dal;
using BrainWare.Dal.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BrainWare.IntegrationTests.Repositories
{
    [TestFixture]
    public class OrderRepositoryTests : BaseRepositoryTests
    {

        
        [Test]
        public void GetCompanyOrders_ShouldReturnACollectionOfOrders_ThatMatchTheCompanyId()
        {
            // Arrange
            var sut = new OrderRepository();

            // Act
            var result = sut.GetOrdersByCompanyId(1);

            // Assert
            result.Should().NotBeEmpty();
        }
    }
}