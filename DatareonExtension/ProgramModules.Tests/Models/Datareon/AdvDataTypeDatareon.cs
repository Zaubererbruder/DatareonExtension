using DT;
using DT.MdmMetadata.CoreEntity;
using DT.MdmMetadata.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using SystemModels;

namespace ProgramModules.Tests.Models
{
    public sealed class AdvDataTypeDatareon : BaseClass, IDataType

    {
        public static readonly Guid TypeId = Guid.Parse("60577b1f-2a63-4fd3-90f5-959f6d70644b");
        public static readonly bool IsCategory = false;
        private int _dummy;

        /// <summary>
        /// , Nullable
        /// </summary>
        [JsonProperty]
        public Int32? IntNullable { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty]
        public Int32 IntNotNullable { get; set; }


        /// <summary>
        /// , Nullable
        /// </summary>
        [JsonProperty]
        public Boolean? BooleanNullable { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty]
        public Boolean BooleanNotNullable { get; set; }


        /// <summary>
        /// 	String [50], Nullable
        /// </summary>
        [JsonProperty]
        public string String50Nullable
        {
            get => __core_String50Nullable;
            set
            {
                if (value?.Length > 50)
                    throw new ArgumentException("Длина поля [String50Nullable] превышает допустимую длину в 50 символов.");


                __core_String50Nullable = value;
            }
        }

        private string __core_String50Nullable = default;



        /// <summary>
        /// 	String [50]
        /// </summary>
        [JsonProperty(Required = Required.DisallowNull)]
        public string String50NotNullable
        {
            get => __core_String50NotNullable;
            set
            {
                if (value == null)
                    throw new ArgumentException("Значение переменной [String50NotNullable] не может быть null.");
                if (value.Length > 50)
                    throw new ArgumentException("Длина поля [String50NotNullable] превышает допустимую длину в 50 символов.");


                __core_String50NotNullable = value;
            }
        }

        private string __core_String50NotNullable = string.Empty;



        /// <summary>
        /// 	String [Max]
        /// </summary>
        [JsonProperty(Required = Required.DisallowNull)]
        public string StringMax
        {
            get => __core_StringMax;
            set
            {
                if (value == null)
                    throw new ArgumentException("Значение переменной [StringMax] не может быть null.");


                __core_StringMax = value;
            }
        }

        private string __core_StringMax = string.Empty;



        /// <summary>
        /// 	String [10]
        /// </summary>
        [JsonProperty(Required = Required.DisallowNull)]
        public string String50Trim
        {
            get => __core_String50Trim;
            set
            {
                if (value == null)
                    value = string.Empty;
                if (value.Length > 10)
                    value = value.Substring(0, 10);


                __core_String50Trim = value;
            }
        }

        private string __core_String50Trim = string.Empty;



        /// <summary>
        /// 	Decimal [5, 0], Nullable
        /// </summary>
        [JsonProperty]
        public decimal? Decimal50Nullable
        {
            get => __core_Decimal50Nullable;
            set
            {
                if (value == null)
                {
                    __core_Decimal50Nullable = null;
                    return;
                }

                if (value != null)
                    value = DecimalValidator.Validate(value.Value, 5, 0, "Decimal50Nullable", false);

                __core_Decimal50Nullable = value;
            }
        }
        private decimal? __core_Decimal50Nullable = default;



        /// <summary>
        /// 	Decimal [5, 0]
        /// </summary>
        [JsonProperty]
        public decimal Deciaml50NotNullable
        {
            get => __core_Deciaml50NotNullable;
            set
            {
                value = DecimalValidator.Validate(value, 5, 0, "Deciaml50NotNullable", false);

                __core_Deciaml50NotNullable = value;
            }
        }
        private decimal __core_Deciaml50NotNullable = default;



        /// <summary>
        /// 	Decimal [5, 2]
        /// </summary>
        [JsonProperty]
        public decimal Decimal52NotRound
        {
            get => __core_Decimal52NotRound;
            set
            {
                value = DecimalValidator.Validate(value, 5, 2, "Decimal52NotRound", false);

                __core_Decimal52NotRound = value;
            }
        }
        private decimal __core_Decimal52NotRound = default;



        /// <summary>
        /// 	Decimal [5, 2]
        /// </summary>
        [JsonProperty]
        public decimal Decimal52Round
        {
            get => __core_Decimal52Round;
            set
            {
                value = DecimalValidator.Validate(value, 5, 2, "Decimal52Round", true);

                __core_Decimal52Round = value;
            }
        }
        private decimal __core_Decimal52Round = default;



        /// <summary>
        /// 
        /// </summary>
        [JsonProperty]
        public DateTime DateWithoutTimeZone
        {
            get => __core_DateWithoutTimeZone;
            set
            {
                if (value == default(DateTime))
                {
                    __core_DateWithoutTimeZone = DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Unspecified);
                    return;
                }



                __core_DateWithoutTimeZone = value;
            }
        }
        private DateTime __core_DateWithoutTimeZone = DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Unspecified);



        /// <summary>
        /// 
        /// </summary>
        [JsonProperty]
        public DateTime DateUTC
        {
            get => __core_DateUTC;
            set
            {
                if (value == default(DateTime))
                {
                    __core_DateUTC = DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Utc);
                    return;
                }



                __core_DateUTC = value;
            }
        }
        private DateTime __core_DateUTC = DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Utc);



        /// <summary>
        /// 
        /// </summary>
        [JsonProperty]
        public DateTime DateLocal
        {
            get => __core_DateLocal;
            set
            {
                if (value == default(DateTime))
                {
                    __core_DateLocal = DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Local);
                    return;
                }



                __core_DateLocal = value;
            }
        }
        private DateTime __core_DateLocal = DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Local);



        /// <summary>
        /// 
        /// </summary>
        [JsonProperty]
        public DateTime DateTrim
        {
            get => __core_DateTrim;
            set
            {
                if (value == default(DateTime))
                {
                    __core_DateTrim = DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Unspecified);
                    return;
                }

                if (value.Year < 1900)
                    value = new DateTime(1900, 1, 1, 0, 0, 0);

                __core_DateTrim = value;
            }
        }
        private DateTime __core_DateTrim = DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Unspecified);



        /// <summary>
        /// , Nullable
        /// </summary>
        [JsonProperty]
        public DateTime? DateNullable
        {
            get => __core_DateNullable;
            set
            {
                if (value == null)
                {
                    __core_DateNullable = null;
                    return;
                }



                __core_DateNullable = value;
            }
        }
        private DateTime? __core_DateNullable = null;



        /// <summary>
        /// , Nullable
        /// </summary>
        [JsonProperty]
        public Guid? GuidNullable { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty]
        public Guid GuidNotNullable { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty]
        public AdvDataTypeDatareon_Inner Inner
        {
            get => __core_Inner;
            set => __core_Inner = value ?? new AdvDataTypeDatareon_Inner();
        }
        private AdvDataTypeDatareon_Inner __core_Inner = new AdvDataTypeDatareon_Inner();


        /// <summary>
        /// , Nullable
        /// </summary>
        [JsonProperty]
        public AdvDataTypeDatareon_Inner InnerNullable { get; set; } = new AdvDataTypeDatareon_Inner();


        /// <summary>
        /// , Массив
        /// </summary>
        [JsonProperty]
        public OwnList<AdvDataTypeDatareon_Inner> InnerArray
        {
            get => __core_InnerArray;
            set => __core_InnerArray = value ?? new OwnList<AdvDataTypeDatareon_Inner>("InnerArray", false);
        }
        private OwnList<AdvDataTypeDatareon_Inner> __core_InnerArray = new OwnList<AdvDataTypeDatareon_Inner>("InnerArray", false);


        /// <summary>
        /// , Массив, Nullable
        /// </summary>
        [JsonProperty]
        public OwnList<AdvDataTypeDatareon_Inner> InnerArrayNullable
        {
            get => __core_InnerArrayNullable;
            set => __core_InnerArrayNullable = value ?? new OwnList<AdvDataTypeDatareon_Inner>("InnerArrayNullable", true);
        }
        private OwnList<AdvDataTypeDatareon_Inner> __core_InnerArrayNullable = new OwnList<AdvDataTypeDatareon_Inner>("InnerArrayNullable", true);


        /// <summary>
        /// 	String [50], Массив
        /// </summary>
        [JsonProperty(Required = Required.DisallowNull)]
        public OwnList<string> StringArray
        {
            get => __core_StringArray;
            set => __core_StringArray = value ?? new OwnList<string>(new StringOptions { Length = 50, MaxLength = false, AutoTrim = false }, false, "StringArray");
        }
        private OwnList<string> __core_StringArray = new OwnList<string>(new StringOptions { Length = 50, MaxLength = false, AutoTrim = false }, false, "StringArray");



        public override bool IsDefault()
        {
            return DummyField == default && IntNullable == default
         && IntNotNullable == default
         && BooleanNullable == default
         && BooleanNotNullable == default
         && String50Nullable == default
         && String50NotNullable == string.Empty
         && StringMax == string.Empty
         && String50Trim == string.Empty
         && Decimal50Nullable == default
         && Deciaml50NotNullable == default
         && Decimal52NotRound == default
         && Decimal52Round == default
         && DateWithoutTimeZone == DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Unspecified)
         && DateUTC == DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Utc)
         && DateLocal == DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Local)
         && DateTrim == DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Unspecified)
         && DateNullable == default
         && GuidNullable == default
         && GuidNotNullable == default
         && Inner.IsDefault()
         && InnerNullable.IsDefault()
         && InnerArray.Count == 0
         && InnerArrayNullable.Count == 0
         && StringArray.Count == 0
        ;
        }

        public AdvDataTypeDatareon()
        {
        }

        public AdvDataTypeDatareon(JObject jObj)
        {
            InitFromJson(jObj);
        }


        public override JObject ToJson(bool trim = false)
        {
            var jObj = base.ToJson();
            if (IntNullable != null)
                jObj["IntNullable"] = JToken.FromObject(IntNullable);
            else
                jObj["IntNullable"] = null;
            if (IntNotNullable != null)
                jObj["IntNotNullable"] = JToken.FromObject(IntNotNullable);
            else
                jObj["IntNotNullable"] = null;
            if (BooleanNullable != null)
                jObj["BooleanNullable"] = JToken.FromObject(BooleanNullable);
            else
                jObj["BooleanNullable"] = null;
            if (BooleanNotNullable != null)
                jObj["BooleanNotNullable"] = JToken.FromObject(BooleanNotNullable);
            else
                jObj["BooleanNotNullable"] = null;
            if (String50Nullable != null)
                jObj["String50Nullable"] = JToken.FromObject(String50Nullable);
            else
                jObj["String50Nullable"] = null;
            if (String50NotNullable != null)
                jObj["String50NotNullable"] = JToken.FromObject(String50NotNullable);
            else
                jObj["String50NotNullable"] = null;
            if (StringMax != null)
                jObj["StringMax"] = JToken.FromObject(StringMax);
            else
                jObj["StringMax"] = null;
            if (String50Trim != null)
                jObj["String50Trim"] = JToken.FromObject(String50Trim);
            else
                jObj["String50Trim"] = null;
            if (Decimal50Nullable != null)
                jObj["Decimal50Nullable"] = JToken.FromObject(Decimal50Nullable);
            else
                jObj["Decimal50Nullable"] = null;
            if (Deciaml50NotNullable != null)
                jObj["Deciaml50NotNullable"] = JToken.FromObject(Deciaml50NotNullable);
            else
                jObj["Deciaml50NotNullable"] = null;
            if (Decimal52NotRound != null)
                jObj["Decimal52NotRound"] = JToken.FromObject(Decimal52NotRound);
            else
                jObj["Decimal52NotRound"] = null;
            if (Decimal52Round != null)
                jObj["Decimal52Round"] = JToken.FromObject(Decimal52Round);
            else
                jObj["Decimal52Round"] = null;
            if (DateWithoutTimeZone != null)
                jObj["DateWithoutTimeZone"] = JToken.FromObject(DateWithoutTimeZone);
            else
                jObj["DateWithoutTimeZone"] = null;
            if (DateUTC != null)
                jObj["DateUTC"] = JToken.FromObject(DateUTC);
            else
                jObj["DateUTC"] = null;
            if (DateLocal != null)
                jObj["DateLocal"] = JToken.FromObject(DateLocal);
            else
                jObj["DateLocal"] = null;
            if (DateTrim != null)
                jObj["DateTrim"] = JToken.FromObject(DateTrim);
            else
                jObj["DateTrim"] = null;
            if (DateNullable != null)
                jObj["DateNullable"] = JToken.FromObject(DateNullable);
            else
                jObj["DateNullable"] = null;
            if (GuidNullable != null)
                jObj["GuidNullable"] = JToken.FromObject(GuidNullable);
            else
                jObj["GuidNullable"] = null;
            if (GuidNotNullable != null)
                jObj["GuidNotNullable"] = JToken.FromObject(GuidNotNullable);
            else
                jObj["GuidNotNullable"] = null;
            if (Inner != null)
                jObj["Inner"] = Inner.ToJson();
            if (InnerNullable != null)
                jObj["InnerNullable"] = InnerNullable.ToJson();
            if (InnerArray != null)
            {
                var __core_arr = new JArray();
                foreach (var item in InnerArray)
                {
                    __core_arr.Add(item.ToJson());
                }
                jObj["InnerArray"] = __core_arr;
            }
            if (InnerArrayNullable != null)
            {
                var __core_arr = new JArray();
                foreach (var item in InnerArrayNullable)
                {
                    __core_arr.Add(item.ToJson());
                }
                jObj["InnerArrayNullable"] = __core_arr;
            }
            if (StringArray != null)
                jObj["StringArray"] = JToken.FromObject(StringArray);
            else
                jObj["StringArray"] = null;
            return jObj;
        }

        public AdvDataTypeDatareon Clone()
        {
            var clone = new AdvDataTypeDatareon();
            clone.IntNullable = IntNullable;
            clone.IntNotNullable = IntNotNullable;
            clone.BooleanNullable = BooleanNullable;
            clone.BooleanNotNullable = BooleanNotNullable;
            clone.String50Nullable = String50Nullable;
            clone.String50NotNullable = String50NotNullable;
            clone.StringMax = StringMax;
            clone.String50Trim = String50Trim;
            clone.Decimal50Nullable = Decimal50Nullable;
            clone.Deciaml50NotNullable = Deciaml50NotNullable;
            clone.Decimal52NotRound = Decimal52NotRound;
            clone.Decimal52Round = Decimal52Round;
            clone.DateWithoutTimeZone = DateWithoutTimeZone;
            clone.DateUTC = DateUTC;
            clone.DateLocal = DateLocal;
            clone.DateTrim = DateTrim;
            clone.DateNullable = DateNullable;
            clone.GuidNullable = GuidNullable;
            clone.GuidNotNullable = GuidNotNullable;
            if (Inner != null)
                clone.Inner = Inner.Clone();
            if (InnerNullable != null)
                clone.InnerNullable = InnerNullable.Clone();
            if (InnerArray != null)
                clone.InnerArray = new OwnList<AdvDataTypeDatareon_Inner>(InnerArray, nameof(InnerArray));
            if (InnerArrayNullable != null)
                clone.InnerArrayNullable = new OwnList<AdvDataTypeDatareon_Inner>(InnerArrayNullable, nameof(InnerArrayNullable));
            if (StringArray != null)
                clone.StringArray = new OwnList<string>(StringArray, nameof(StringArray));
            return clone;
        }

        public override BaseClass DoClone()
        {
            return Clone();
        }

        public LinkType CastToLink()
        {
            var link = new LinkType();
            link.DataTypeId = Guid.Parse("60577b1f-2a63-4fd3-90f5-959f6d70644b");
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
            message.SetDataTypeId(Guid.Parse("60577b1f-2a63-4fd3-90f5-959f6d70644b"));
            message.SetBody(this);
            return message;
        }

        public string GetDescription()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(IntNullable.ToString()))
                sb.Append($"{IntNullable.ToString()} ");

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public string GetFullDescription()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(IntNullable.ToString()))
                sb.Append($"{IntNullable.ToString()} ");

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public string GetFieldStrValue(string fieldName)
        {
            if ("IntNullable" == fieldName)
                return $"{IntNullable.ToString()}";

            if ("IntNotNullable" == fieldName)
                return $"{IntNotNullable.ToString()}";

            if ("BooleanNullable" == fieldName)
                return $"{BooleanNullable.ToString()}";

            if ("BooleanNotNullable" == fieldName)
                return $"{BooleanNotNullable.ToString()}";

            if ("String50Nullable" == fieldName)
                return $"{String50Nullable.ToString()}";

            if ("String50NotNullable" == fieldName)
                return $"{String50NotNullable.ToString()}";

            if ("StringMax" == fieldName)
                return $"{StringMax.ToString()}";

            if ("String50Trim" == fieldName)
                return $"{String50Trim.ToString()}";

            if ("Decimal50Nullable" == fieldName)
                return $"{Decimal50Nullable.ToString()}";

            if ("Deciaml50NotNullable" == fieldName)
                return $"{Deciaml50NotNullable.ToString()}";

            if ("Decimal52NotRound" == fieldName)
                return $"{Decimal52NotRound.ToString()}";

            if ("Decimal52Round" == fieldName)
                return $"{Decimal52Round.ToString()}";

            if ("DateWithoutTimeZone" == fieldName)
                return $"{DateWithoutTimeZone.ToString()}";

            if ("DateUTC" == fieldName)
                return $"{DateUTC.ToString()}";

            if ("DateLocal" == fieldName)
                return $"{DateLocal.ToString()}";

            if ("DateTrim" == fieldName)
                return $"{DateTrim.ToString()}";

            if ("DateNullable" == fieldName)
                return $"{DateNullable.ToString()}";

            if ("GuidNullable" == fieldName)
                return $"{GuidNullable.ToString()}";

            if ("GuidNotNullable" == fieldName)
                return $"{GuidNotNullable.ToString()}";

            if ("Inner" == fieldName)
                return $"{Inner.ToString()}";

            if ("InnerNullable" == fieldName)
                return $"{InnerNullable.ToString()}";

            if ("InnerArray" == fieldName)
                return $"{InnerArray.ToString()}";

            if ("InnerArrayNullable" == fieldName)
                return $"{InnerArrayNullable.ToString()}";

            if ("StringArray" == fieldName)
                return $"{StringArray.ToString()}";

            throw new InvalidOperationException($"Свойство с именем {fieldName} не найдено.");
        }

        public bool HasField(string fieldName)
        {
            if ("IntNullable" == fieldName)
                return true;

            if ("IntNotNullable" == fieldName)
                return true;

            if ("BooleanNullable" == fieldName)
                return true;

            if ("BooleanNotNullable" == fieldName)
                return true;

            if ("String50Nullable" == fieldName)
                return true;

            if ("String50NotNullable" == fieldName)
                return true;

            if ("StringMax" == fieldName)
                return true;

            if ("String50Trim" == fieldName)
                return true;

            if ("Decimal50Nullable" == fieldName)
                return true;

            if ("Deciaml50NotNullable" == fieldName)
                return true;

            if ("Decimal52NotRound" == fieldName)
                return true;

            if ("Decimal52Round" == fieldName)
                return true;

            if ("DateWithoutTimeZone" == fieldName)
                return true;

            if ("DateUTC" == fieldName)
                return true;

            if ("DateLocal" == fieldName)
                return true;

            if ("DateTrim" == fieldName)
                return true;

            if ("DateNullable" == fieldName)
                return true;

            if ("GuidNullable" == fieldName)
                return true;

            if ("GuidNotNullable" == fieldName)
                return true;

            if ("Inner" == fieldName)
                return true;

            if ("InnerNullable" == fieldName)
                return true;

            if ("InnerArray" == fieldName)
                return true;

            if ("InnerArrayNullable" == fieldName)
                return true;

            if ("StringArray" == fieldName)
                return true;

            return false;
        }

        public OwnDictionary<string, object> CastToDictionary()
        {
            var clone = Clone();
            var dict = new OwnDictionary<string, object>("");
            dict.Add(nameof(IntNullable), clone.IntNullable);
            dict.Add(nameof(IntNotNullable), clone.IntNotNullable);
            dict.Add(nameof(BooleanNullable), clone.BooleanNullable);
            dict.Add(nameof(BooleanNotNullable), clone.BooleanNotNullable);
            dict.Add(nameof(String50Nullable), clone.String50Nullable);
            dict.Add(nameof(String50NotNullable), clone.String50NotNullable);
            dict.Add(nameof(StringMax), clone.StringMax);
            dict.Add(nameof(String50Trim), clone.String50Trim);
            dict.Add(nameof(Decimal50Nullable), clone.Decimal50Nullable);
            dict.Add(nameof(Deciaml50NotNullable), clone.Deciaml50NotNullable);
            dict.Add(nameof(Decimal52NotRound), clone.Decimal52NotRound);
            dict.Add(nameof(Decimal52Round), clone.Decimal52Round);
            dict.Add(nameof(DateWithoutTimeZone), clone.DateWithoutTimeZone);
            dict.Add(nameof(DateUTC), clone.DateUTC);
            dict.Add(nameof(DateLocal), clone.DateLocal);
            dict.Add(nameof(DateTrim), clone.DateTrim);
            dict.Add(nameof(DateNullable), clone.DateNullable);
            dict.Add(nameof(GuidNullable), clone.GuidNullable);
            dict.Add(nameof(GuidNotNullable), clone.GuidNotNullable);
            dict.Add(nameof(Inner), clone.Inner);
            dict.Add(nameof(InnerNullable), clone.InnerNullable);
            dict.Add(nameof(InnerArray), clone.InnerArray);
            dict.Add(nameof(InnerArrayNullable), clone.InnerArrayNullable);
            dict.Add(nameof(StringArray), clone.StringArray);
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
            if (!(other is AdvDataTypeDatareon typed))
            {
                return false;
            }
            if (!base.Equals(typed))
            {
                return false;
            }
            return
                EqualsHelper.Equals(IntNullable, typed.IntNullable) &&
                EqualsHelper.Equals(IntNotNullable, typed.IntNotNullable) &&
                EqualsHelper.Equals(BooleanNullable, typed.BooleanNullable) &&
                EqualsHelper.Equals(BooleanNotNullable, typed.BooleanNotNullable) &&
                EqualsHelper.Equals(String50Nullable, typed.String50Nullable) &&
                EqualsHelper.Equals(String50NotNullable, typed.String50NotNullable) &&
                EqualsHelper.Equals(StringMax, typed.StringMax) &&
                EqualsHelper.Equals(String50Trim, typed.String50Trim) &&
                EqualsHelper.Equals(Decimal50Nullable, typed.Decimal50Nullable) &&
                EqualsHelper.Equals(Deciaml50NotNullable, typed.Deciaml50NotNullable) &&
                EqualsHelper.Equals(Decimal52NotRound, typed.Decimal52NotRound) &&
                EqualsHelper.Equals(Decimal52Round, typed.Decimal52Round) &&
                EqualsHelper.Equals(DateWithoutTimeZone, typed.DateWithoutTimeZone) &&
                EqualsHelper.Equals(DateUTC, typed.DateUTC) &&
                EqualsHelper.Equals(DateLocal, typed.DateLocal) &&
                EqualsHelper.Equals(DateTrim, typed.DateTrim) &&
                EqualsHelper.Equals(DateNullable, typed.DateNullable) &&
                EqualsHelper.Equals(GuidNullable, typed.GuidNullable) &&
                EqualsHelper.Equals(GuidNotNullable, typed.GuidNotNullable) &&
                EqualsHelper.Equals(Inner, typed.Inner) &&
                EqualsHelper.Equals(InnerNullable, typed.InnerNullable) &&
                EqualsHelper.Equals(InnerArray, typed.InnerArray) &&
                EqualsHelper.Equals(InnerArrayNullable, typed.InnerArrayNullable) &&
                EqualsHelper.Equals(StringArray, typed.StringArray);
        }

        public void InitFromMessage(Message message)
        {
            var body = message.GetBodyAsObject();
            InitFromJson(body);
        }

        public void InitFromDictionary(OwnDictionary<string, object> dict)
        {
            object dictValue;
            if (dict.TryGetValue("IntNullable", out dictValue) && (dictValue is Int32 IntNullableTyped))
            {
                IntNullable = IntNullableTyped;
            }
            if (dict.TryGetValue("IntNotNullable", out dictValue) && (dictValue is Int32 IntNotNullableTyped))
            {
                IntNotNullable = IntNotNullableTyped;
            }
            if (dict.TryGetValue("BooleanNullable", out dictValue) && (dictValue is Boolean BooleanNullableTyped))
            {
                BooleanNullable = BooleanNullableTyped;
            }
            if (dict.TryGetValue("BooleanNotNullable", out dictValue) && (dictValue is Boolean BooleanNotNullableTyped))
            {
                BooleanNotNullable = BooleanNotNullableTyped;
            }
            if (dict.TryGetValue("String50Nullable", out dictValue) && (dictValue is String String50NullableTyped))
            {
                String50Nullable = String50NullableTyped;
            }
            if (dict.TryGetValue("String50NotNullable", out dictValue) && (dictValue is String String50NotNullableTyped))
            {
                String50NotNullable = String50NotNullableTyped;
            }
            if (dict.TryGetValue("StringMax", out dictValue) && (dictValue is String StringMaxTyped))
            {
                StringMax = StringMaxTyped;
            }
            if (dict.TryGetValue("String50Trim", out dictValue) && (dictValue is String String50TrimTyped))
            {
                String50Trim = String50TrimTyped;
            }
            if (dict.TryGetValue("Decimal50Nullable", out dictValue) && (dictValue is Decimal Decimal50NullableTyped))
            {
                Decimal50Nullable = Decimal50NullableTyped;
            }
            if (dict.TryGetValue("Deciaml50NotNullable", out dictValue) && (dictValue is Decimal Deciaml50NotNullableTyped))
            {
                Deciaml50NotNullable = Deciaml50NotNullableTyped;
            }
            if (dict.TryGetValue("Decimal52NotRound", out dictValue) && (dictValue is Decimal Decimal52NotRoundTyped))
            {
                Decimal52NotRound = Decimal52NotRoundTyped;
            }
            if (dict.TryGetValue("Decimal52Round", out dictValue) && (dictValue is Decimal Decimal52RoundTyped))
            {
                Decimal52Round = Decimal52RoundTyped;
            }
            if (dict.TryGetValue("DateWithoutTimeZone", out dictValue) && (dictValue is DateTime DateWithoutTimeZoneTyped))
            {
                DateWithoutTimeZone = DateWithoutTimeZoneTyped;
            }
            if (dict.TryGetValue("DateUTC", out dictValue) && (dictValue is DateTime DateUTCTyped))
            {
                DateUTC = DateUTCTyped;
            }
            if (dict.TryGetValue("DateLocal", out dictValue) && (dictValue is DateTime DateLocalTyped))
            {
                DateLocal = DateLocalTyped;
            }
            if (dict.TryGetValue("DateTrim", out dictValue) && (dictValue is DateTime DateTrimTyped))
            {
                DateTrim = DateTrimTyped;
            }
            if (dict.TryGetValue("DateNullable", out dictValue) && (dictValue is DateTime DateNullableTyped))
            {
                DateNullable = DateNullableTyped;
            }
            if (dict.TryGetValue("GuidNullable", out dictValue) && (dictValue is Guid GuidNullableTyped))
            {
                GuidNullable = GuidNullableTyped;
            }
            if (dict.TryGetValue("GuidNotNullable", out dictValue) && (dictValue is Guid GuidNotNullableTyped))
            {
                GuidNotNullable = GuidNotNullableTyped;
            }
            if (dict.TryGetValue("Inner", out dictValue) && (dictValue is AdvDataTypeDatareon_Inner InnerTyped))
            {
                Inner = InnerTyped?.Clone();
            }
            if (dict.TryGetValue("InnerNullable", out dictValue) && (dictValue is AdvDataTypeDatareon_Inner InnerNullableTyped))
            {
                InnerNullable = InnerNullableTyped?.Clone();
            }
            if (dict.TryGetValue("InnerArray", out dictValue) && (dictValue is OwnList<AdvDataTypeDatareon_Inner> InnerArrayTyped))
            {
                if (InnerArray != null)
                    InnerArray.LoadArray(InnerArrayTyped);
            }
            if (dict.TryGetValue("InnerArrayNullable", out dictValue) && (dictValue is OwnList<AdvDataTypeDatareon_Inner> InnerArrayNullableTyped))
            {
                if (InnerArrayNullable != null)
                    InnerArrayNullable.LoadArray(InnerArrayNullableTyped);
            }
            if (dict.TryGetValue("StringArray", out dictValue) && (dictValue is OwnList<String> StringArrayTyped))
            {
                StringArray.LoadArray(StringArrayTyped);
            }
        }

        public override void InitFromJson(JObject jObj)
        {
            if (BaseClassUtils.TryFillPropertyFromJObject<Int32?>("IntNullable", jObj, out var __core_IntNullable_))
            {
                IntNullable = __core_IntNullable_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<Int32>("IntNotNullable", jObj, out var __core_IntNotNullable_))
            {
                IntNotNullable = __core_IntNotNullable_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<Boolean?>("BooleanNullable", jObj, out var __core_BooleanNullable_))
            {
                BooleanNullable = __core_BooleanNullable_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<Boolean>("BooleanNotNullable", jObj, out var __core_BooleanNotNullable_))
            {
                BooleanNotNullable = __core_BooleanNotNullable_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<String>("String50Nullable", jObj, out var __core_String50Nullable_))
            {
                String50Nullable = __core_String50Nullable_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<String>("String50NotNullable", jObj, out var __core_String50NotNullable_))
            {
                String50NotNullable = __core_String50NotNullable_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<String>("StringMax", jObj, out var __core_StringMax_))
            {
                StringMax = __core_StringMax_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<String>("String50Trim", jObj, out var __core_String50Trim_))
            {
                String50Trim = __core_String50Trim_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<Decimal?>("Decimal50Nullable", jObj, out var __core_Decimal50Nullable_))
            {
                Decimal50Nullable = __core_Decimal50Nullable_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<Decimal>("Deciaml50NotNullable", jObj, out var __core_Deciaml50NotNullable_))
            {
                Deciaml50NotNullable = __core_Deciaml50NotNullable_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<Decimal>("Decimal52NotRound", jObj, out var __core_Decimal52NotRound_))
            {
                Decimal52NotRound = __core_Decimal52NotRound_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<Decimal>("Decimal52Round", jObj, out var __core_Decimal52Round_))
            {
                Decimal52Round = __core_Decimal52Round_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<DateTime>("DateWithoutTimeZone", jObj, out var __core_DateWithoutTimeZone_))
            {
                DateWithoutTimeZone = __core_DateWithoutTimeZone_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<DateTime>("DateUTC", jObj, out var __core_DateUTC_))
            {
                DateUTC = __core_DateUTC_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<DateTime>("DateLocal", jObj, out var __core_DateLocal_))
            {
                DateLocal = __core_DateLocal_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<DateTime>("DateTrim", jObj, out var __core_DateTrim_))
            {
                DateTrim = __core_DateTrim_;
            }
            if (BaseClassUtils.TryFillPropertyFromJObject<DateTime?>("DateNullable", jObj, out var __core_DateNullable_))
            {
                DateNullable = __core_DateNullable_;
            }
            if (BaseClassUtils.TryFillGuidProperty("GuidNullable", true, jObj, out var __core_GuidNullable_))
            {
                GuidNullable = __core_GuidNullable_;
            }
            else
            {
                GuidNullable = null;
            }
            if (BaseClassUtils.TryFillGuidProperty("GuidNotNullable", false, jObj, out var __core_GuidNotNullable_))
            {
                GuidNotNullable = __core_GuidNotNullable_.Value;
            }
            else
            {
                GuidNotNullable = default;
            }
            BaseClassUtils.FillProperty(Inner, "Inner", jObj);
            BaseClassUtils.FillProperty(InnerNullable, "InnerNullable", jObj);
            {
                var item = jObj["InnerArray"];
                if (!item.IsNull())
                {
                    InnerArray = new OwnList<AdvDataTypeDatareon_Inner>(nameof(InnerArray), false);
                    if (item is JArray jArr)
                    {
                        foreach (var j in jArr)
                        {
                            if (j is JObject jo)
                            {
                                var newObj = new AdvDataTypeDatareon_Inner(jo);
                                InnerArray.Add(newObj);
                            }
                        }
                    }
                    else if (item is JObject childObj)
                    {
                        if (childObj is JObject jo)
                        {
                            var newObj = new AdvDataTypeDatareon_Inner(jo);
                            InnerArray.Add(newObj);
                        }
                    }
                }
            }
            {
                var item = jObj["InnerArrayNullable"];
                if (!item.IsNull())
                {
                    InnerArrayNullable = new OwnList<AdvDataTypeDatareon_Inner>(nameof(InnerArrayNullable), true);
                    if (item is JArray jArr)
                    {
                        foreach (var j in jArr)
                        {
                            if (j is JObject jo)
                            {
                                var newObj = new AdvDataTypeDatareon_Inner(jo);
                                InnerArrayNullable.Add(newObj);
                            }
                        }
                    }
                    else if (item is JObject childObj)
                    {
                        if (childObj is JObject jo)
                        {
                            var newObj = new AdvDataTypeDatareon_Inner(jo);
                            InnerArrayNullable.Add(newObj);
                        }
                    }
                }
            }
            {
                var item = jObj["StringArray"];
                if (!item.IsNull())
                {
                    StringArray = new OwnList<String>(new StringOptions { Length = 50, MaxLength = false, AutoTrim = false }, false, "StringArray");
                    if (item is JArray jArr)
                    {
                        foreach (var j in jArr)
                        {
                            if (j is JObject _obj && j["StringArray"] != null)
                            {
                                StringArray.Add(BaseClassUtils.FillProperty<String>(j["StringArray"]));
                            }
                            else
                            {
                                StringArray.Add(BaseClassUtils.FillProperty<String>(j));
                            }
                        }
                    }
                    else if (item is JObject childObj)
                    {
                        StringArray.Add(BaseClassUtils.FillProperty<String>(childObj));
                    }
                }
            }
        }

        public void RequiredFieldsExists()
        {
            var dateTimeEthalon_c5e98603 = DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Utc);
            var emptySet = new HashSet<string>();
            if (emptySet.Count > 0)
                throw new Exception("Не указаны значения для обязательных полей:" + string.Join(",", emptySet));
        }



    }
}
