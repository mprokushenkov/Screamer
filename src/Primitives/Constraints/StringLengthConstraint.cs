using static System.String;
using static Bstm.Primitives.Constraints.CheckResult;
using static Bstm.Primitives.Constraints.Messages;
using static Bstm.Primitives.Guard;

namespace Bstm.Primitives.Constraints
{
    public sealed class StringLengthConstraint : IConstraint<string>
    {
        private readonly uint length;

        public StringLengthConstraint(uint length) => this.length = length;

        public CheckResult Check(string value)
        {
            CheckNull(value, nameof(value));

            return value.Length == length
                ? CreateSucceeded()
                : CreateViolated(Format(StringLengthConstraint_Violation, length, value.Length));
        }
    }
}