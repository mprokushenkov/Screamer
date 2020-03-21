namespace Screamer.Primitives.Constraints
{
    public interface IConstraint<in T>
    {
        CheckResult Check(T value);
    }
}