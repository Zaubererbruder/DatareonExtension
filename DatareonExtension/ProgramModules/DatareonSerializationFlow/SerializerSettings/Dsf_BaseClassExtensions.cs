using Newtonsoft.Json;
using SystemModels;

public static class Dsf_BaseClassExtensions
{
    /// <summary>
    /// Создает конвертер для BaseClass с настройками сериализации по умолчанию
    /// </summary>
    /// <param name="baseClass">Экземпляр BaseClass для конвертации</param>
    /// <returns>Конвертер с настройками сериализации по умолчанию</returns>
    public static Dsf_Converter.BaseClassConverter WithDefaultSettings(this BaseClass baseClass)
    {
        Dsf_Converter.BaseClassConverter converter = new Dsf_Converter.BaseClassConverter(baseClass, null);
        return converter;
    }

    /// <summary>
    /// Создает конвертер для BaseClass с пользовательскими настройками сериализации
    /// </summary>
    /// <param name="baseClass">Экземпляр BaseClass для конвертации</param>
    /// <param name="settings">Пользовательские настройки сериализации JSON</param>
    /// <returns>Конвертер с указанными настройками сериализации</returns>
    public static Dsf_Converter.BaseClassConverter WithCustomSettings(this BaseClass baseClass, JsonSerializerSettings settings)
    {
        Dsf_Converter.BaseClassConverter converter = new Dsf_Converter.BaseClassConverter(baseClass, settings);
        return converter;
    }
}