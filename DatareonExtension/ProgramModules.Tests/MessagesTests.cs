using Newtonsoft.Json;
using ProgramModules.Tests.Models;
using SystemModels;
using static ProgramModules.AbsMessageExtensions;

namespace ProgramModules.Tests
{
    public class MessagesTests
    {
        AdvDataType AdvDataType {  get; set; }
        Message Message { get; set; }

        public MessagesTests()
        {
            AdvDataType = new AdvDataType()
            {
                Guid = Guid.NewGuid(),
                Name = "Name",
                Count = 1,
                Date = DateTime.Now
            };
            string json = JsonConvert.SerializeObject(AdvDataType);

            Message = new Message();
            Message.SetBody(json);
        }

        [Fact]
        public void CreateDefaultConverter()
        {
            AbsMessageConverter converter = Message.SetDefaultSettings();
            Assert.NotNull(converter.Message);
            Assert.NotNull(converter.SerializerSettings);
            Assert.Equivalent(new JsonSerializerSettings(), converter.SerializerSettings, true);
        }
        
        [Fact]
        public void CreateCustomConverter()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;

            AbsMessageConverter converter = Message.SetCustomSettings(settings);
            Assert.Equivalent(settings, converter.SerializerSettings, true);
        }

        [Fact]
        public void DeserializeToDatareonTypeWithDefault()
        {
            var obj = Message.SetDefaultSettings()
                .To<AdvDataTypeDatareon>();

            Assert.IsType<AdvDataTypeDatareon>(obj);
            Assert.Equal(AdvDataType.Guid, obj.Guid);
            Assert.Equal(AdvDataType.Name, obj.Name);
            Assert.NotEqual(AdvDataType.Count, obj.CountSmart);
            Assert.Equal(AdvDataType.Date, obj.Date);
        }

        [Fact]
        public void DeserializeToDatareonTypeWithChangePropNames()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = ABS.CustomContractResolver.CreateBuilder()
                                            .MapProperty("CountSmart", "Count")
                                            .Build();

            var obj = Message.SetCustomSettings(settings)
                .To<AdvDataTypeDatareon>();

            Assert.IsType<AdvDataTypeDatareon>(obj);
            Assert.Equal(AdvDataType.Guid, obj.Guid);
            Assert.Equal(AdvDataType.Name, obj.Name);
            Assert.Equal(AdvDataType.Count, obj.CountSmart);
            Assert.Equal(AdvDataType.Date, obj.Date);
        }
    }
}