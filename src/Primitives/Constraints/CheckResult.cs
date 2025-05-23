using static Bstm.Primitives.Guard;

namespace Bstm.Primitives.Constraints
{
    public readonly struct CheckResult
    {
        private static readonly CheckResult succeeded = new(false, string.Empty);

        private CheckResult(bool violated, string message)
        {
            Violated = violated;
            Message = CheckNull(message, nameof(message));
        }

        public bool Violated { get; }

        public string Message { get; }

        public static CheckResult CreateSucceeded() => succeeded;

        public static CheckResult CreateViolated(string message) => new(true, message);
    }
}