namespace Bstm.Primitives.Constraints
{
    public interface IConstraint<in T>
    {
        CheckResult Check(T value);
    }
}