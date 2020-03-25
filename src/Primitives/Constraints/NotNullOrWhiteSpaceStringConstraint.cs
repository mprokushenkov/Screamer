using static System.String;
using static Screamer.Primitives.Constraints.CheckResult;
using static Screamer.Primitives.Constraints.Messages;

namespace Screamer.Primitives.Constraints
{
    public sealed class NotNullOrWhiteSpaceStringConstraint : IConstraint<string>
    {
        public CheckResult Check(string value) => IsNullOrWhiteSpace(value)
            ? CreateViolated(NotNullOrWhiteSpaceStringConstraint_Violation)
            : Succeeded;
    }
}