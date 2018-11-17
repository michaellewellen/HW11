using System;
using System.IO;
using HW11.Types;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Moq;

namespace HW11.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            

            var c = new Person("FirstName", "LastName", 50);
            var dataStoreMock = new Mock<IDataStore>();
            var peopleRepo = new PeopleRepository(dataStoreMock.Object);

            var result = peopleRepo.AddPerson(c);
            Assert.IsTrue(result);
        }
    }
}
