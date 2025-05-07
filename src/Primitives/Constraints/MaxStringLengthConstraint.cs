using static System.String;
using static Bstm.Primitives.Constraints.CheckResult;
using static Bstm.Primitives.Constraints.Messages;
using static Bstm.Primitives.Guard;

namespace Bstm.Primitives.Constraints
{
    public sealed class MaxStringLengthConstraint : IConstraint<string>
    {
        private readonly uint maxLength;

        public MaxStringLengthConstraint(uint maxLength) => this.maxLength = maxLength;

        public CheckResult Check(string value)
        {
            CheckNull(value, nameof(value));

            return value.Length <= maxLength
                ? CreateSucceeded()
                : CreateViolated(Format(MaxStringLengthConstraint_Violation, maxLength, value.Length));
        }
    }
}