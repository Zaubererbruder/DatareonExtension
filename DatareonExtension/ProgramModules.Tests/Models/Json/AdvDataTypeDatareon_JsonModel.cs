public class AdvDataTypeDatareon_JsonModel
{
    public int? IntNullable { get; set; }
    public int IntNotNullable { get; set; }
    public bool? BooleanNullable { get; set; }
    public bool BooleanNotNullable { get; set; }
    public string String50Nullable { get; set; }
    public string String50NotNullable { get; set; }
    public string StringMax { get; set; }
    public string String50Trim { get; set; }
    public decimal? Decimal50Nullable { get; set; }
    public decimal Deciaml50NotNullable { get; set; }
    public decimal Decimal52NotRound { get; set; }
    public decimal Decimal52Round { get; set; }
    public DateTime DateWithoutTimeZone { get; set; }
    public DateTime DateUTC { get; set; }
    public DateTime DateLocal { get; set; }
    public DateTime DateTrim { get; set; }
    public DateTime? DateNullable { get; set; }
    public Guid? GuidNullable { get; set; }
    public Guid GuidNotNullable { get; set; }
    public AdvDataTypeDatareon_Inner_JsonModel Inner { get; set; }
    public AdvDataTypeDatareon_Inner_JsonModel InnerNullable { get; set; }
    public List<AdvDataTypeDatareon_Inner_JsonModel> InnerArray { get; set; }
    public List<AdvDataTypeDatareon_Inner_JsonModel> InnerArrayNullable { get; set; }
    public List<string> StringArray { get; set; }
}