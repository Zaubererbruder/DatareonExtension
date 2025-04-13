using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModels;

namespace ProgramModules
{
    public static class AbsMessageExtensions
    {
        public static AbsMessageConverter SetDefaultSettings(this Message message)
        {
            AbsMessageConverter messageConverter = new AbsMessageConverter(message, null);
            return messageConverter;
        }

        public static AbsMessageConverter SetCustomSettings(this Message message, JsonSerializerSettings settings)
        {
            AbsMessageConverter messageConverter = new AbsMessageConverter(message, settings);
            return messageConverter;
        }

        public class AbsMessageConverter
        {
            public Message Message { get; private set; }
            public JsonSerializerSettings SerializerSettings { get; private set; }

            public AbsMessageConverter(Message message, JsonSerializerSettings? serializerSettings)
            {
                Message = message;
                SerializerSettings = serializerSettings ?? new JsonSerializerSettings();
            }

            public T? To<T>() where T : BaseClass, new()
            {
                return JsonConvert.DeserializeObject<T>(Message.GetBodyAsString(), SerializerSettings);
            }
        }
    }
}
