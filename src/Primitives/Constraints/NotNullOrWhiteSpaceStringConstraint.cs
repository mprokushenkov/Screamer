using static System.String;
using static Bstm.Primitives.Constraints.CheckResult;
using static Bstm.Primitives.Constraints.Messages;

namespace Bstm.Primitives.Constraints
{
    public sealed class NotNullOrWhiteSpaceStringConstraint : IConstraint<string>
    {
        public CheckResult Check(string value) => IsNullOrWhiteSpace(value)
            ? CreateViolated(NotNullOrWhiteSpaceStringConstraint_Violation)
            : CreateSucceeded();
    }
}