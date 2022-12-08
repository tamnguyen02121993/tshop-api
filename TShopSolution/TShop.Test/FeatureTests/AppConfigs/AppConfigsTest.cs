using Moq;
using TShop.Api.Models;
using TShop.Api.Repositories.AppConfigs;
using TShop.Contracts.Utils.Enums;

namespace TShop.Test.FeatureTests.AppConfigs
{
    public class AppConfigsTest
    {
        [Fact]
        public void CreateAppConfig_ReturnAppConfigResponse()
        {
            // Arrange
            var appConfigRepository = new Mock<IAppConfigRepository>();
            var request = new AppConfig()
            {
                Id = 1,
                Key = "Key",
                Value = "Value",
                Status = Status.ACTIVE,
            };
            appConfigRepository.Setup(x => x.CreateAppConfig(It.IsAny<AppConfig>())).ReturnsAsync(request);

            // Act
            var response = appConfigRepository.Object.CreateAppConfig(new AppConfig());

            // Assert
            Assert.Equal(request.Id, response.Result.Id);
            Assert.Equal(request.Key, response.Result.Key);
            Assert.Equal(request.Value, response.Result.Value);
            Assert.Equal(request.Status, response.Result.Status);
        }
    }
}
