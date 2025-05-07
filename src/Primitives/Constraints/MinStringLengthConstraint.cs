using static System.String;
using static Bstm.Primitives.Constraints.CheckResult;
using static Bstm.Primitives.Guard;
using static Bstm.Primitives.Constraints.Messages;

namespace Bstm.Primitives.Constraints
{
    public sealed class MinStringLengthConstraint : IConstraint<string>
    {
        private readonly uint minLength;

        public MinStringLengthConstraint(uint minLength) => this.minLength = minLength;

        public CheckResult Check(string value)
        {
            CheckNull(value, nameof(value));

            return value.Length >= minLength
                ? CreateSucceeded()
                : CreateViolated(Format(MinStringLengthConstraint_Violation, minLength, value.Length));
        }
    }
}