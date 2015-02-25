namespace GUT.Infra.Specifications
{
    public interface ISpecification
    {
        bool IsSatisfiedBy(object value);
    }
}
