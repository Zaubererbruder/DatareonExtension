using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace ProgramModules
{
    public static class ABS
    {
        /// <summary>
        /// Custom JSON contract resolver that allows mapping C# property names to different JSON field names.
        /// </summary>
        public class CustomContractResolver : DefaultContractResolver
        {
            private readonly Dictionary<string, string> _propertyMappings;

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomContractResolver"/> class with the specified property mappings.
            /// </summary>
            /// <param name="propertyMappings">A dictionary where the key is the C# property name and the value is the JSON field name.</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="propertyMappings"/> is null.</exception>
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

            /// <summary>
            /// Creates a new builder instance for fluently configuring <see cref="CustomContractResolver"/>.
            /// </summary>
            /// <returns>A new instance of <see cref="CustomContractResolverBuilder"/>.</returns>
            public static CustomContractResolverBuilder CreateBuilder() => new CustomContractResolverBuilder();
        }

        /// <summary>
        /// Fluent builder for configuring property mappings in <see cref="CustomContractResolver"/>.
        /// </summary>
        public class CustomContractResolverBuilder
        {
            private readonly Dictionary<string, string> _mappings = new Dictionary<string, string>();

            public int DummyField { get; private set; }

            /// <summary>
            /// Maps a C# property name to a JSON field name.
            /// </summary>
            /// <param name="propertyName">The name of the C# property.</param>
            /// <param name="jsonName">The name of the JSON field.</param>
            /// <returns>The current builder instance for method chaining.</returns>
            /// <exception cref="ArgumentException">Thrown if <paramref name="propertyName"/> or <paramref name="jsonName"/> is null or empty.</exception>
            public CustomContractResolverBuilder MapProperty(string propertyName, string jsonName)
            {
                if (string.IsNullOrEmpty(propertyName))
                    throw new ArgumentException("Property name cannot be null or empty", nameof(propertyName));

                if (string.IsNullOrEmpty(jsonName))
                    throw new ArgumentException("JSON name cannot be null or empty", nameof(jsonName));

                _mappings[propertyName] = jsonName;
                return this;
            }

            /// <summary>
            /// Builds a <see cref="CustomContractResolver"/> with the configured property mappings.
            /// </summary>
            /// <returns>A new instance of <see cref="CustomContractResolver"/>.</returns>
            /// <exception cref="InvalidOperationException">Thrown if no property mappings were defined.</exception>
            public CustomContractResolver Build()
            {
                if (_mappings.Count == 0)
                    throw new InvalidOperationException("No property mappings were defined.");

                return new CustomContractResolver(_mappings);
            }
        }
    }
}
