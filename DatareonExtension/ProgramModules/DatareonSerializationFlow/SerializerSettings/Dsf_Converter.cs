using Newtonsoft.Json;
using SystemModels;

public static class Dsf_Converter
{
    /// <summary>
    /// Конвертер сообщений с поддержкой настройки сериализации JSON
    /// </summary>
    public class MessageConverter : BaseConverter<MessageConverter>
    {
        /// <summary>
        /// Сообщение для конвертации
        /// </summary>
        public Message Message { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр конвертера сообщений
        /// </summary>
        /// <param name="message">Сообщение для конвертации</param>
        /// <param name="serializerSettings">Настройки сериализации (если null, будут использованы настройки по умолчанию)</param>
        public MessageConverter(Message message, JsonSerializerSettings? serializerSettings) : base(serializerSettings)
        {
            Message = message;
        }

        /// <summary>
        /// Выполняет десериализацию сообщения в указанный тип
        /// </summary>
        /// <typeparam name="T">Тип, в который выполняется десериализация (должен наследовать BaseClass)</typeparam>
        /// <returns>Десериализованный объект или null</returns>
        public T? To<T>() where T : BaseClass, new()
        {
            if (ContractResolverBuilder != null)
                SerializerSettings.ContractResolver = ContractResolverBuilder.Build();

            return JsonConvert.DeserializeObject<T>(Message.GetBodyAsString(), SerializerSettings);
        }
    }

    public class BaseClassConverter : BaseConverter<BaseClassConverter>
    {
        /// <summary>
        /// Сообщение для конвертации
        /// </summary>
        public BaseClass BaseClass { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр конвертера сообщений
        /// </summary>
        /// <param name="message">Сообщение для конвертации</param>
        /// <param name="serializerSettings">Настройки сериализации (если null, будут использованы настройки по умолчанию)</param>
        public BaseClassConverter(BaseClass baseClass, JsonSerializerSettings? serializerSettings) : base(serializerSettings)
        {
            BaseClass = baseClass;
        }

        /// <summary>
        /// Выполняет десериализацию сообщения в указанный тип
        /// </summary>
        /// <typeparam name="T">Тип, в который выполняется десериализация (должен наследовать BaseClass)</typeparam>
        /// <returns>Десериализованный объект или null</returns>
        public string ToJson()
        {
            if (ContractResolverBuilder != null)
                SerializerSettings.ContractResolver = ContractResolverBuilder.Build();

            return JsonConvert.SerializeObject(BaseClass, SerializerSettings);
        }
    }

    public class BaseConverter<T> : BaseConverter where T : BaseConverter
    {

        public BaseConverter(JsonSerializerSettings? serializerSettings) : base(serializerSettings) { }

        /// <summary>
        /// Устанавливает обработку имен типов при сериализации
        /// </summary>
        /// <param name="typeNameHandling">Поведение обработки имен типов</param>
        /// <returns>Текущий экземпляр конвертера для цепочки вызовов</returns>
        public virtual T WithTypeNameHandling(TypeNameHandling typeNameHandling)
        {
            SerializerSettings.TypeNameHandling = typeNameHandling;
            return (T)(BaseConverter)this;
        }

        /// <summary>
        /// Устанавливает обработку null-значений при сериализации
        /// </summary>
        /// <param name="nullValueHandling">Поведение обработки null-значений</param>
        /// <returns>Текущий экземпляр конвертера для цепочки вызовов</returns>
        public virtual T WithNullValueHandling(NullValueHandling nullValueHandling)
        {
            SerializerSettings.NullValueHandling = nullValueHandling;
            return (T)(BaseConverter)this;
        }

        /// <summary>
        /// Добавляет сопоставление имени свойства класса с именем поля в JSON
        /// </summary>
        /// <param name="propertyName">Имя свойства в классе</param>
        /// <param name="jsonName">Имя поля в JSON</param>
        /// <returns>Текущий экземпляр конвертера для цепочки вызовов</returns>
        public virtual T WithPropertyName(string propertyName, string jsonName)
        {
            if (ContractResolverBuilder == null)
                ContractResolverBuilder = new Dsf_ContractResolvers.ContractResolverBuilder();
            ContractResolverBuilder = ContractResolverBuilder.MapProperty(propertyName, jsonName);
            return (T)(BaseConverter)this;
        }
    }

    public class BaseConverter
    {
        protected Dsf_ContractResolvers.ContractResolverBuilder ContractResolverBuilder { get; set; }

        /// <summary>
        /// Настройки сериализации JSON
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; protected set; }

        public BaseConverter(JsonSerializerSettings? serializerSettings)
        {
            SerializerSettings = serializerSettings ?? new JsonSerializerSettings();
        }
    }
}