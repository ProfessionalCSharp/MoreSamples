using System.Globalization;
using WebLocalizationSample.Services;
using Xunit;

namespace TestWebLocalizationSample
{
    public class TestHostToCultureMapping
    {
        [Fact]
        void TestGetCultureForHostGerman()
        {
            // arrange
            var mapping = new HostToCultureMapping();
            string host = "www.cninnovation.at";

            // act
            CultureInfo culture = mapping.GetCultureForHost(host);

            // assert
            Assert.Equal("de-DE", culture.Name);
        }

        [Theory, InlineData("www.cninnovation.com"), InlineData("localhost")]
        void TestGetCultureForHostDefault(string host)
        {
            // arrange
            var mapping = new HostToCultureMapping();

            // act
            CultureInfo culture = mapping.GetCultureForHost(host);

            // assert
            Assert.Equal("en-US", culture.Name);
        }
    }
}