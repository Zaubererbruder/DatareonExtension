using Newtonsoft.Json;
using SystemModels;

public static class Dsf_MessageExtensions
{
    /// <summary>
    /// Создает конвертер сообщений с настройками сериализации по умолчанию
    /// </summary>
    /// <param name="message">Сообщение для конвертации</param>
    /// <returns>Экземпляр конвертера с настройками по умолчанию</returns>
    public static Dsf_Converter.MessageConverter WithDefaultSettings(this Message message)
    {
        Dsf_Converter.MessageConverter converter = new Dsf_Converter.MessageConverter(message, null);
        return converter;
    }

    /// <summary>
    /// Создает конвертер сообщений с пользовательскими настройками сериализации
    /// </summary>
    /// <param name="message">Сообщение для конвертации</param>
    /// <param name="settings">Пользовательские настройки сериализации JSON</param>
    /// <returns>Экземпляр конвертера с указанными настройками</returns>
    public static Dsf_Converter.MessageConverter WithCustomSettings(this Message message, JsonSerializerSettings settings)
    {
        Dsf_Converter.MessageConverter converter = new Dsf_Converter.MessageConverter(message, settings);
        return converter;
    }
}