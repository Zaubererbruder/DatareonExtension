using Newtonsoft.Json;
using SystemModels;

public class Dsf_MessageExtensionsTests
{
    [Fact]
    public void WithDefaultSettings_Should_CreateConverterWithDefaultSettings()
    {
        // Arrange
        var message = new Message();

        // Act
        var converter = message.WithDefaultSettings();

        // Assert
        Assert.NotNull(converter);
        Assert.Same(message, converter.Message);
        Assert.NotNull(converter.SerializerSettings);
        Assert.Equivalent(new JsonSerializerSettings(), converter.SerializerSettings, true);
    }

    [Fact]
    public void WithCustomSettings_Should_UseProvidedSettings()
    {
        // Arrange
        var message = new Message();
        var customSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        // Act
        var converter = message.WithCustomSettings(customSettings);

        // Assert
        Assert.Same(customSettings, converter.SerializerSettings);
    }
}
