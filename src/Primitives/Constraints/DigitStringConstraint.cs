using System.Linq;
using static Bstm.Primitives.Constraints.CheckResult;
using static Bstm.Primitives.Constraints.Messages;

namespace Bstm.Primitives.Constraints
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