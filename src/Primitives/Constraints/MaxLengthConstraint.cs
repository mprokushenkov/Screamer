using static System.String;
using static Screamer.Primitives.Constraints.Messages;
using static Screamer.Primitives.Guard;

namespace Screamer.Primitives.Constraints
{
    public sealed class MaxLengthConstraint : IConstraint<string>
    {
        private readonly uint length;

        public MaxLengthConstraint(uint length) => this.length = length;

        public CheckResult Check(string value)
        {
            CheckNull(value, nameof(value));

            return value.Length <= length
                ? CheckResult.Succeeded
                : CheckResult.CreateViolated(Format(MaxLengthConstraint_Violation, length, value.Length));
        }
    }
}