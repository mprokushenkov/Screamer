using System.Linq;
using static System.String;
using static Screamer.Primitives.Constraints.Messages;

namespace Screamer.Primitives.Constraints
{
    public sealed class DigitStringConstraint : IConstraint<string>
    {
        public CheckResult Check(string value)
        {
            Guard.CheckNull(value, nameof(value));

            return IsNullOrWhiteSpace(value) || value.Any(c => !char.IsDigit(c))
                ? CheckResult.CreateViolated(NumericStringConstraint_Violation)
                : CheckResult.Succeeded;
        }
    }
}