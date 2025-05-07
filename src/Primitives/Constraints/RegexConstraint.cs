using System;
using System.Text.RegularExpressions;
using static System.String;
using static Bstm.Primitives.Constraints.CheckResult;
using static Bstm.Primitives.Guard;

namespace Bstm.Primitives.Constraints
{
    public sealed class RegexConstraint : IConstraint<string>
    {
        private readonly string pattern;
        private readonly Lazy<Regex> regexLazy;

        public RegexConstraint(string pattern)
        {
            this.pattern = CheckNull(pattern, nameof(pattern));
            regexLazy = new Lazy<Regex>(() => new Regex(this.pattern));
        }

        public CheckResult Check(string value)
        {
            CheckNull(value, nameof(value));

            return regexLazy.Value.IsMatch(value)
                ? CreateSucceeded()
                : CreateViolated(Format(Messages.RegexConstraint_Violation, pattern));
        }
    }
}