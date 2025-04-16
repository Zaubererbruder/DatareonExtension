using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class Dsf_ContractResolversTests
{
    public class TestModel
    {
        public int TaskCount { get; set; }
        public string UserName { get; set; }
    }

    [Fact]
    public void CustomContractResolver_Should_MapPropertiesCorrectly()
    {
        // Arrange
        var mappings = new Dictionary<string, string>
        {
            ["TaskCount"] = "count",
            ["UserName"] = "user"
        };
        var resolver = new Dsf_ContractResolvers.CustomContractResolver(mappings);
        var settings = new JsonSerializerSettings { ContractResolver = resolver };

        var json = @"{""count"":5,""user"":""John""}";

        // Act
        var result = JsonConvert.DeserializeObject<TestModel>(json, settings);

        // Assert
        Assert.Equal(5, result.TaskCount);
        Assert.Equal("John", result.UserName);
    }

    [Fact]
    public void ContractResolverBuilder_Should_BuildDefaultResolver_When_NoMappings()
    {
        // Arrange
        var builder = new Dsf_ContractResolvers.ContractResolverBuilder();

        // Act
        var resolver = builder.Build();

        // Assert
        Assert.IsType<DefaultContractResolver>(resolver);
    }

    [Fact]
    public void ContractResolverBuilder_Should_AllowMethodChaining()
    {
        // Arrange
        var builder = new Dsf_ContractResolvers.ContractResolverBuilder();

        // Act
        var result = builder.MapProperty("A", "a")
                           .MapProperty("B", "b");

        // Assert
        Assert.Same(builder, result);
    }

    [Fact]
    public void ContractResolverBuilder_Should_Throw_When_InvalidArguments()
    {
        var builder = new Dsf_ContractResolvers.ContractResolverBuilder();

        Assert.Throws<ArgumentException>(() => builder.MapProperty(null, "a"));
        Assert.Throws<ArgumentException>(() => builder.MapProperty("A", null));
    }
}
