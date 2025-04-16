using Newtonsoft.Json;
using SystemModels;

public class Dsf_Converter_MessageConverterTests
{
    public class TestModel : BaseClass
    {
        public int Value { get; set; }
    }

    [Fact]
    public void MessageConverter_Should_DeserializeWithCustomSettings()
    {
        // Arrange
        var message = new Message();
        message.SetBody("{\"Value\":42}");
        var converter = new Dsf_Converter.MessageConverter(message, null)
            .WithTypeNameHandling(TypeNameHandling.None)
            .WithNullValueHandling(NullValueHandling.Ignore);
        // Act
        var result = converter.To<TestModel>();

        // Assert
        Assert.Equal(42, result.Value);
        Assert.Equal(TypeNameHandling.None, converter.SerializerSettings.TypeNameHandling);
        Assert.Equal(NullValueHandling.Ignore, converter.SerializerSettings.NullValueHandling);
    }

    [Fact]
    public void MessageConverter_Should_ApplyPropertyMappings()
    {
        // Arrange
        var message = new Message();
        message.SetBody("{\"val\":42}");
        var converter = new Dsf_Converter.MessageConverter(message, null)
            .WithPropertyName("Value", "val");

        // Act
        var result = converter.To<TestModel>();

        // Assert
        Assert.Equal(42, result.Value);
    }
}
