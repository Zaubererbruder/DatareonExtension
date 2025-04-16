using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

public static class Dsf_ContractResolvers
{
    /// <summary>
    /// Пользовательский резолвер контрактов JSON, позволяющий сопоставлять имена свойств C# с разными именами полей JSON.
    /// </summary>
    public class CustomContractResolver : DefaultContractResolver
    {
        private readonly Dictionary<string, string> _propertyMappings;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CustomContractResolver"/> с указанными сопоставлениями свойств.
        /// </summary>
        /// <param name="propertyMappings">Словарь, где ключ - имя свойства C#, а значение - имя поля JSON.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если <paramref name="propertyMappings"/> равен null.</exception>
        public CustomContractResolver(Dictionary<string, string> propertyMappings)
        {
            _propertyMappings = propertyMappings ?? throw new ArgumentNullException(nameof(propertyMappings));
        }

        /// <inheritdoc />
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (_propertyMappings.TryGetValue(property.PropertyName, out var jsonName))
            {
                property.PropertyName = jsonName;
            }

            return property;
        }
    }

    /// <summary>
    /// Fluent-билдер для настройки сопоставлений свойств в <see cref="CustomContractResolver"/>.
    /// </summary>
    public class ContractResolverBuilder : Dsf_Dummy.DummyClass
    {
        private readonly Dictionary<string, string> _mappings = new Dictionary<string, string>();

        /// <summary>
        /// Сопоставляет имя свойства C# с именем поля JSON.
        /// </summary>
        /// <param name="propertyName">Имя свойства C#.</param>
        /// <param name="jsonName">Имя поля JSON.</param>
        /// <returns>Текущий экземпляр билдера для цепочки вызовов.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если <paramref name="propertyName"/> или <paramref name="jsonName"/> равны null или пусты.</exception>
        public ContractResolverBuilder MapProperty(string propertyName, string jsonName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Имя свойства не может быть null или пустым", nameof(propertyName));

            if (string.IsNullOrEmpty(jsonName))
                throw new ArgumentException("Имя JSON не может быть null или пустым", nameof(jsonName));

            _mappings[propertyName] = jsonName;
            return this;
        }

        /// <summary>
        /// Создает <see cref="CustomContractResolver"/> с настроенными сопоставлениями свойств.
        /// </summary>
        /// <returns>Новый экземпляр <see cref="CustomContractResolver"/>.</returns>
        /// <exception cref="InvalidOperationException">Выбрасывается, если не определено ни одного сопоставления свойств.</exception>
        public DefaultContractResolver Build()
        {
            if (_mappings.Count == 0)
                return new DefaultContractResolver();

            return new CustomContractResolver(_mappings);
        }
    }
}