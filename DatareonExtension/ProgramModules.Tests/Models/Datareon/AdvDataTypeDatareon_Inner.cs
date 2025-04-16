using DT.MdmMetadata.CoreEntity;
using DT;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModels;

namespace ProgramModules.Tests.Models
{
    public sealed class AdvDataTypeDatareon_Inner : BaseClass, IDataType

    {
        public static readonly Guid TypeId = Guid.Parse("5350088c-629f-4364-b463-dc8477e01094");
        public static readonly bool IsCategory = false;
        private int _dummy;

        /// <summary>
        /// 	String [50]
        /// </summary>
        [JsonProperty(Required = Required.DisallowNull)]
        public string Test
        {
            get => __core_Test;
            set
            {
                if (value == null)
                    throw new ArgumentException("Значение переменной [Test] не может быть null.");
                if (value.Length > 50)
                    throw new ArgumentException("Длина поля [Test] превышает допустимую длину в 50 символов.");


                __core_Test = value;
            }
        }

        private string __core_Test = string.Empty;




        public override bool IsDefault()
        {
            return DummyField == default && Test == string.Empty
        ;
        }

        public AdvDataTypeDatareon_Inner()
        {
        }

        public AdvDataTypeDatareon_Inner(JObject jObj)
        {
            InitFromJson(jObj);
        }


        public override JObject ToJson(bool trim = false)
        {
            var jObj = base.ToJson();
            if (Test != null)
                jObj["Test"] = JToken.FromObject(Test);
            else
                jObj["Test"] = null;
            return jObj;
        }

        public AdvDataTypeDatareon_Inner Clone()
        {
            var clone = new AdvDataTypeDatareon_Inner();
            clone.Test = Test;
            return clone;
        }

        public override BaseClass DoClone()
        {
            return Clone();
        }

        public LinkType CastToLink()
        {
            var link = new LinkType();
            link.DataTypeId = Guid.Parse("5350088c-629f-4364-b463-dc8477e01094");
            return link;
        }

        public Entity ToEntity()
        {
            var entity = new Entity();
            entity.Content = ToJson();
            entity.TableId = GetTypeId();
            entity.DataTypeId = GetTypeId();
            return entity;
        }

        public Guid GetEntityId()
        {
            throw new ArgumentException("Тип данных не является объектом.");
        }

        public Guid GetTypeId()
        {
            return TypeId;
        }

        public DateTime GetCreated()
        {
            throw new ArgumentException("Тип данных не является объектом.");
        }

        public DateTime GetUpdated()
        {
            throw new ArgumentException("Тип данных не является объектом.");
        }

        public Guid GetVersion()
        {
            throw new ArgumentException("Тип данных не является объектом.");
        }

        public Message CastToMessage()
        {
            var message = new Message();
            message.Id = Guid.NewGuid().ToString();
            message.CreationDate = DateTime.Now;
            message.SetDataTypeId(Guid.Parse("5350088c-629f-4364-b463-dc8477e01094"));
            message.SetBody(this);
            return message;
        }

        public string GetDescription()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Test))
                sb.Append($"{Test.ToString()} ");

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public string GetFullDescription()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Test))
                sb.Append($"{Test.ToString()} ");

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public string GetFieldStrValue(string fieldName)
        {
            if ("Test" == fieldName)
                return $"{Test.ToString()}";

            throw new InvalidOperationException($"Свойство с именем {fieldName} не найдено.");
        }

        public bool HasField(string fieldName)
        {
            if ("Test" == fieldName)
                return true;

            return false;
        }

        public OwnDictionary<string, object> CastToDictionary()
        {
            var clone = Clone();
            var dict = new OwnDictionary<string, object>("");
            dict.Add(nameof(Test), clone.Test);
            return dict;
        }

        public InternalMessage CreateMessage()
        {
            var message = new InternalMessage();
            message.DataType = TypeId;
            message.Body = Encoding.UTF8.GetBytes(ToJson().ToString(Newtonsoft.Json.Formatting.None));
            return message;
        }

        public override bool Equals(object other)
        {
            if (!(other is AdvDataTypeDatareon_Inner typed))
            {
                return false;
            }
            if (!base.Equals(typed))
            {
                return false;
            }
            return
                EqualsHelper.Equals(Test, typed.Test);
        }

        public void InitFromMessage(Message message)
        {
            var body = message.GetBodyAsObject();
            InitFromJson(body);
        }

        public void InitFromDictionary(OwnDictionary<string, object> dict)
        {
            object dictValue;
            if (dict.TryGetValue("Test", out dictValue) && (dictValue is String TestTyped))
            {
                Test = TestTyped;
            }
        }

        public override void InitFromJson(JObject jObj)
        {
            if (BaseClassUtils.TryFillPropertyFromJObject<String>("Test", jObj, out var __core_Test_))
            {
                Test = __core_Test_;
            }
        }

        public void RequiredFieldsExists()
        {
            var dateTimeEthalon_43f86e63 = DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Utc);
            var emptySet = new HashSet<string>();
            if (emptySet.Count > 0)
                throw new Exception("Не указаны значения для обязательных полей:" + string.Join(",", emptySet));
        }



    }
}
