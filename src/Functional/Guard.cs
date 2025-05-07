namespace Bstm.Functional;

internal static class Guard
{
    public static T CheckNull<T>(T value, string name)
        where T : class
        => value is null ? throw new ArgumentNullException(name) : value;
}
