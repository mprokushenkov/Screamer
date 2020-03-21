using static System.String;
using static Screamer.Primitives.Guard;
using static Screamer.Primitives.Constraints.Messages;

namespace Screamer.Primitives.Constraints
{
    public sealed class MinStringLengthConstraint : IConstraint<string>
    {
        private readonly uint length;

        public MinStringLengthConstraint(uint length) => this.length = length;

        public CheckResult Check(string value)
        {
            CheckNull(value, nameof(value));

            return value.Length >= length
                ? CheckResult.Succeeded
                : CheckResult.CreateViolated(Format(MinStringLengthConstraint_Violation, length, value.Length));
        }
    }
}