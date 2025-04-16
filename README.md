# Datareon Serialization Fluent

## Класс MyDataType
```csharp
public class MyDataType : BaseClass
{
    public Guid Id { get; set; }
    public int CountSmart { get; set; }
    public string messageText { get; set; }
    public DateTime Date { get; set; }
    public int? NullableInt { get; set; }
}
```

## 1. Сериализация

```csharp
var data = new MyDataType 
{
    Id = Guid.NewGuid(),
    CountSmart = 42,
    messageText = "Hello world",
    Date = DateTime.Now,
    NullableInt = null
};

string json = data.WithDefaultSettings()
                     .WithTypeNameHandling(TypeNameHandling.None)
                     .WithNullValueHandling(NullValueHandling.Ignore)
                     .WithPropertyName("CountSmart", "Count")
                     .WithPropertyName("messageText", "message")
                     .ToJson();
```
Результат:
```json
{
  "Id": "a1b2c3d4-1234-5678-9101-112131415161",
  "Count": 42,
  "message": "Hello world",
  "Date": "2023-11-15T14:30:00.1234567Z"
}
```
WithTypeNameHandling.None - убирает $type из json. Другие варианты: https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_TypeNameHandling.htm
WithNullValueHandling.Ignore - не выводит null поле в json. Другие варианты: https://www.newtonsoft.com/json/help/html/t_newtonsoft_json_nullvaluehandling.htm

## 2. Десериализация

Тело сообщения:
```json
{
  "Id": "b2c3d4e5-2345-6789-1011-121314151617",
  "Count": 100,
  "message": "Test message",
  "Date": "2023-11-16T09:15:00Z"
}
```

```csharp
MyDataType result = InitMessage.WithDefaultSettings()
                   .WithPropertyName("CountSmart", "Count")
                   .WithPropertyName("messageText", "message")
                   .To<MyDataType>();
```
Результат:
```
MyDataType {
  Id: b2c3d4e5-2345-6789-1011-121314151617,
  CountSmart: 100,
  messageText: "Test message",
  Date: 2023-11-16 09:15:00Z
}
```

## 3. Использование кастомных настроек (WithCustomSettings)
https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonSerializerSettings.htm

```csharp
var data = new MyDataType 
{
    Id = Guid.NewGuid(),
    CountSmart = 7,
    messageText = null,
    Date = new DateTime(2023, 11, 17)
};

var customSettings = new JsonSerializerSettings
{
    NullValueHandling = NullValueHandling.Ignore,
    DateFormatString = "yyyy-MM-dd",
    Formatting = Formatting.None
};

string json = data.WithCustomSettings(customSettings)
                     .WithPropertyName("CountSmart", "Count")
                     .ToJson();
```
Результат:
```json
{"Id":"c3d4e5f6-3456-7891-0111-213141516171","totalCount":7,"Date":"2023-11-17"}
```


## P.S.
```csharp
string json = data.WithDefaultSettings().ToJson()
Равносильно
string json = JsonConvert.SerializeObject(data);

////////////////////////////////////////////////////////////////////////

string json = data.WithCustomSettings(someSettings).ToJson()
Равносильно
string json = JsonConvert.SerializeObject(data, someSettings);

////////////////////////////////////////////////////////////////////////

string json = data.WithDefaultSettings()
                     .WithTypeNameHandling(TypeNameHandling.None)
                     .WithNullValueHandling(NullValueHandling.Ignore)
Равносильно
string json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
              {
                TypeNameHandling = TypeNameHandling.None,
                NullValueHandling = NullValueHandling.None
              });

////////////////////////////////////////////////////////////////////////

MyDataType result = InitMessage.WithDefaultSettings()
                   .WithPropertyName("CountSmart", "Count")
                   .WithPropertyName("messageText", "message")
                   .To<MyDataType>();
Равносильно
var json = InitMessage.GetBodyAsString();
MyDataType result = JsonConvert.DeserializeObject<MyDataType>(json, new JsonSerializerSettings
                    {
                        ContractResolver = new Dsf_ContractResolvers.ContractResolverBuilder()
                                               .MapProperty("CountSmart", "Count")
                                               .MapProperty("messageText", "message")
                                               .Build()
                    })
Равносильно
var json = InitMessage.GetBodyAsString()
            .Replace("\""Count\":", "\"CountSmart\":");
            .Replace("\"message\":", "\"messageText\":");
MyDataType result = JsonConvert.DeserializeObject<MyDataType>(json);

```