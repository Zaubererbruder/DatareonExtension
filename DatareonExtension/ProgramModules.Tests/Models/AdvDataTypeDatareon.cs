using DT.MdmMetadata.CoreEntity;
using Newtonsoft.Json;
using SystemModels;

namespace ProgramModules.Tests.Models
{
    public sealed class AdvDataTypeDatareon : BaseClass, IDataType
    {
        public static readonly Guid TypeId = Guid.NewGuid();
        public static readonly bool IsCategory = false;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty]
        public Guid Guid { get; set; }


        /// <summary>
        /// 	String [50], Nullable
        /// </summary>
        [JsonProperty]
        public string Name
        {
            get => __core_Name;
            set
            {
                if (value?.Length > 50)
                    throw new ArgumentException("Длина поля [Name] превышает допустимую длину в 50 символов.");


                __core_Name = value;
            }
        }

        private string __core_Name = default;



        /// <summary>
        /// , Nullable
        /// </summary>
        [JsonProperty]
        public Int32? CountSmart { get; set; }


        /// <summary>
        /// , Nullable
        /// </summary>
        [JsonProperty]
        public DateTime? Date
        {
            get => __core_Date;
            set
            {
                if (value == null)
                {
                    __core_Date = null;
                    return;
                }



                __core_Date = value;
            }
        }
        private DateTime? __core_Date = null;


        public Message CastToMessage()
        {
            var message = new Message();
            message.Id = Guid.NewGuid().ToString();
            message.CreationDate = DateTime.Now;
            message.SetDataTypeId(TypeId);
            message.SetBody(this);
            return message;
        }

        public DateTime GetCreated()
        {
            throw new ArgumentException("Тип данных не является объектом.");
        }

        public Guid GetEntityId()
        {
            throw new ArgumentException("Тип данных не является объектом.");
        }

        public Guid GetTypeId()
        {
            return TypeId;
        }

        public DateTime GetUpdated()
        {
            throw new ArgumentException("Тип данных не является объектом.");
        }

        public Guid GetVersion()
        {
            throw new ArgumentException("Тип данных не является объектом.");
        }

        public Entity ToEntity()
        {
            var entity = new Entity();
            entity.Content = ToJson();
            entity.TableId = GetTypeId();
            entity.DataTypeId = GetTypeId();
            return entity;
        }
    }
}
