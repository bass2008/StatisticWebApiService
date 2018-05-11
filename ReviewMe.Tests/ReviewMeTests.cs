using NUnit.Framework;
using ReviewMe.Web;
using ReviewMe.Web.Services;
using Unity;

namespace ReviewMe.Tests
{
    [TestFixture]
    public class ReviewMeIntegrationTests
    {
        private const string TestUserName = "TestUser";

        private const int TestCount = 5;

        [TestCase]
        public void ReviewMeSimpleIntegrationTest()
        {
            // Arrange
            var serviceLocator = UnityConfig.Container;
            var statisticService = serviceLocator.Resolve<StatisticService>();
            
            // Act
            var firstCount = statisticService.GetVisitorsCountAsync(TestUserName).Result;
            statisticService.AddVisitorsCountAsync(TestUserName, TestCount).Wait();
            var newCount = statisticService.GetVisitorsCountAsync(TestUserName).Result;
            statisticService.ClearVisitorsCountAsync(TestUserName).Wait();
            var endCount = statisticService.GetVisitorsCountAsync(TestUserName).Result;
            
            // Assert
            Assert.IsTrue(firstCount == 0);
            Assert.IsTrue(newCount == TestCount);
            Assert.IsTrue(endCount == 0);
        }
    }
}
