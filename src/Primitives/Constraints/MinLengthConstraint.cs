using static System.String;
using static Screamer.Primitives.Guard;
using static Screamer.Primitives.Constraints.Messages;

namespace Screamer.Primitives.Constraints
{
    public sealed class MinLengthConstraint : IConstraint<string>
    {
        private readonly uint length;

        public MinLengthConstraint(uint length) => this.length = length;

        public CheckResult Check(string value)
        {
            CheckNull(value, nameof(value));

            return value.Length >= length
                ? CheckResult.Succeeded
                : CheckResult.CreateViolated(Format(MinLengthConstraint_Violation, length, value.Length));
        }
    }
}