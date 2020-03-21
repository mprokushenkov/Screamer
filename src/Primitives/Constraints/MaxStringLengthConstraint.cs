using static System.String;
using static Screamer.Primitives.Constraints.Messages;
using static Screamer.Primitives.Guard;

namespace Screamer.Primitives.Constraints
{
    public sealed class MaxStringLengthConstraint : IConstraint<string>
    {
        private readonly uint length;

        public MaxStringLengthConstraint(uint length) => this.length = length;

        public CheckResult Check(string value)
        {
            CheckNull(value, nameof(value));

            return value.Length <= length
                ? CheckResult.Succeeded
                : CheckResult.CreateViolated(Format(MaxStringLengthConstraint_Violation, length, value.Length));
        }
    }
}