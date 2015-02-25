namespace GUT.Entities.CustomTypes
{
    public class GenericEnumIntTypeMapper<TEnum> : EnumIntType
    {
        public GenericEnumIntTypeMapper() : base(typeof(TEnum))
        {
        }
    }
}