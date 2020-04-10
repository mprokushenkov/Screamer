using System.Linq;
using static Screamer.Primitives.Constraints.CheckResult;
using static Screamer.Primitives.Constraints.Messages;

namespace Screamer.Primitives.Constraints
{
    public sealed class DigitStringConstraint : IConstraint<string>
    {
        public CheckResult Check(string value)
        {
            Guard.CheckNull(value, nameof(value));

            return value.Length == 0 || value.Any(c => !char.IsDigit(c))
                ? CreateViolated(NumericStringConstraint_Violation)
                : CreateSucceeded();
        }
    }
}