namespace GUT.Entities.CustomTypes
{
    public class GenericEnumCharTypeMapper<TEnum> : EnumCharType
    {
        public GenericEnumCharTypeMapper() : base(typeof(TEnum))
        {
        }
    }
}