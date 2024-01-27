using System;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using NUnit.Framework;
using TestContainers.Container.Abstractions.Hosting;
using TestContainers.Container.Database.Hosting;
using Testcontainers.MsSql;
using Web.Infrastructure;
using MsSqlContainer = TestContainers.Container.Database.MsSql.MsSqlContainer;

namespace BrainWare.IntegrationTests.Repositories
{
    // use this class to create a base class for all repository tests
    // This class should use the test  containers  library to  create a container  from a Docker file
    // The container should be started before each test and stopped after each test
    // The container should be created with a connection string that points to a test database
    // The test database should be created from a script in the Docker file
    // The test database should be destroyed when the container is stopped
    // The test database should be created with a user name and password
    // The user name and password should be passed to the container as environment variables
    
    
    public class BaseRepositoryTests
    {
        private const string TestDbName = "BrainWareTestDb";
        private MsSqlContainer MsSqlContainer;

        protected Database Database;
        
        [SetUp]
        public async Task SetUp()
        { 
            //var mssqlContainer = new ContainerBuilder<MsSqlContainer>()
               
             //   .Build();
                
                // Database = new Database(MsSqlContainer.ConnectionString);
            
        }
        
        [TearDown]
        public async Task TearDown()
        {
            await MsSqlContainer.StopAsync();
        }
    }
}