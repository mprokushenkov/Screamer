using static System.Environment;
using static Bstm.Primitives.Guard;

namespace Bstm.Primitives.Constraints
{
    public abstract class ConstrainedType<T> where T : notnull
    {
        protected ConstrainedType(T value, params IConstraint<T>[] constraints)
        {
            CheckNull(value, nameof(value));

            var results = constraints.Select(c => c.Check(value)).Where(r => r.Violated).ToArray();

            if (results.Any())
            {
                var message = results.Select(r => r.Message).Aggregate((acc, v) => $"{acc}{NewLine}{v}");
                throw new ArgumentOutOfRangeException(null, value, message);
            }

            Value = value;
        }

        public T Value { get; }

        public override string ToString() => Value.ToString()!;
    }
}