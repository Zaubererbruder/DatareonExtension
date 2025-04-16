using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using SystemModels;

namespace ProgramModules.Tests
{
    public class Dsf_Converter_BaseClassConverterTests
    {
        public class TestModel : BaseClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [Fact]
        public void ToJson_Should_SerializeWithDefaultSettings()
        {
            // Arrange
            var model = new TestModel { Id = 1, Name = "Test" };
            var converter = model.WithDefaultSettings();

            // Act
            var json = converter.ToJson();
            var deserialized = JsonConvert.DeserializeObject<TestModel>(json);

            // Assert
            Assert.Equal(model.Id, deserialized.Id);
            Assert.Equal(model.Name, deserialized.Name);
        }

        [Fact]
        public void ToJson_Should_UseCustomSerializerSettings()
        {
            // Arrange
            var model = new TestModel { Id = 1, Name = "Test" };
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
            var converter = model.WithCustomSettings(settings);

            // Act
            var json = converter.ToJson();

            // Assert
            Assert.Contains("\n", json); // Проверяем форматирование
            Assert.DoesNotContain("null", json); // Проверяем игнорирование null
        }

        [Fact]
        public void WithTypeNameHandling_Should_ConfigureTypeNameHandling()
        {
            // Arrange
            var model = new TestModel();
            var converter = model.WithDefaultSettings();

            // Act
            converter.WithTypeNameHandling(TypeNameHandling.All);
            var json = converter.ToJson();

            // Assert
            Assert.Contains("$type", json);
            Assert.Equal(TypeNameHandling.All, converter.SerializerSettings.TypeNameHandling);
        }

        [Fact]
        public void WithNullValueHandling_Should_ConfigureNullHandling()
        {
            // Arrange
            var model = new TestModel { Name = null };
            var converter = model.WithDefaultSettings();

            // Act
            converter.WithNullValueHandling(NullValueHandling.Ignore);
            var json = converter.ToJson();

            // Assert
            Assert.DoesNotContain("Name", json);
            Assert.Equal(NullValueHandling.Ignore, converter.SerializerSettings.NullValueHandling);
        }

        [Fact]
        public void WithPropertyName_Should_ConfigurePropertyMappings()
        {
            // Arrange
            var model = new TestModel { Id = 1 };
            var converter = model.WithDefaultSettings();

            // Act
            converter.WithPropertyName("Id", "identifier");
            var json = converter.ToJson();

            // Assert
            Assert.Contains("identifier", json);
            Assert.DoesNotContain("Id", json);
        }

        [Fact]
        public void ToJson_Should_HandleNullValuesCorrectly()
        {
            // Arrange
            var model = new TestModel { Id = 1, Name = null };
            var converter = model.WithDefaultSettings();

            // Act (по умолчанию NullValueHandling.Include)
            var json = converter.ToJson();

            // Assert
            Assert.Contains("null", json);
        }

        [Fact]
        public void ToJson_Should_SupportFluentConfiguration()
        {
            // Arrange
            var model = new TestModel { Id = 1, Name = "Test" };

            // Act
            var converter = model.WithDefaultSettings();
            var json = converter
                           .WithTypeNameHandling(TypeNameHandling.None)
                           .WithNullValueHandling(NullValueHandling.Ignore)
                           .WithPropertyName("Name", "title")
                           .ToJson();

            var deserialized = JsonConvert.DeserializeObject<TestModel>(json, converter.SerializerSettings);

            // Assert
            Assert.Equal(model.Id, deserialized.Id);
            Assert.Equal(model.Name, deserialized.Name);
            Assert.Contains("title", json);
        }

        [Fact]
        public void ToJson_Should_UseCustomContractResolver()
        {
            // Arrange
            var model = new TestModel { Id = 1, Name = "Test" };
            var resolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var settings = new JsonSerializerSettings
            {
                ContractResolver = resolver
            };
            var converter = model.WithCustomSettings(settings);

            // Act
            var json = converter.ToJson();

            // Assert
            Assert.Contains("id", json);
            Assert.Contains("name", json);
        }
    }
}
