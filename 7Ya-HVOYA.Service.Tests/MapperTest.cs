using AutoMapper;
using _7YA_HVOYA.Services.Automappers;
using Xunit;

namespace _7YA_HVOYA.Services.Tests
{
    public class MapperTest
    {
        /// <summary>
        /// Тесты на маппер
        /// </summary>
        [Fact]
        public void TestMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });

            config.AssertConfigurationIsValid();
        }
    }
}
