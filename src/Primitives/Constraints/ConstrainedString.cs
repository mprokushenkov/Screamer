using System;
using System.Linq;
using static Screamer.Primitives.Guard;

namespace Screamer.Primitives.Constraints
{
    public abstract class ConstrainedString
    {
        protected ConstrainedString(string value, params IConstraint<string>[] constraints)
        {
            CheckNull(value, nameof(value));

            var results = constraints.Select(c => c.Check(value)).Where(r => r.Violated).ToArray();

            if (results.Any())
            {
                var message = results.Select(r => r.Message).Aggregate((acc, v) => $"{acc}{Environment.NewLine}{v}");
                throw new ArgumentOutOfRangeException(nameof(value), value, message);
            }

            Value = value;
        }

        public string Value { get; }

        public override string ToString() => Value;

        public static implicit operator string(ConstrainedString cs) => cs?.Value!;
    }
}