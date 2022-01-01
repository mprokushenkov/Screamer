using static Screamer.Primitives.Guard;

namespace Screamer.Primitives.Constraints
{
    public abstract class ConstrainedString : ConstrainedType<string>
    {
        protected ConstrainedString(string value, params IConstraint<string>[] constraints) : base(value, constraints)
        {
        }

        public static implicit operator string(ConstrainedString subject) => CheckNull(subject?.Value!, nameof(subject));
    }
}