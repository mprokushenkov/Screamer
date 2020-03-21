using static Screamer.Primitives.Guard;

namespace Screamer.Primitives.Constraints
{
    public readonly struct CheckResult
    {
        private CheckResult(bool violated, string message)
        {
            Violated = violated;
            Message = CheckNull(message, nameof(message));
        }

        public bool Violated { get; }

        public string Message { get; }

        public static CheckResult Succeeded = new CheckResult(false, string.Empty);

        public static CheckResult CreateViolated(string message) => new CheckResult(true, message);
    }
}