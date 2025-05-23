using static Bstm.Functional.Guard;

namespace Bstm.Functional;

public static class Currying
{
    public static Func<T1, Func<T2, TResult>> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> func)
    {
        CheckNull(func, nameof(func));
        return t1 => t2 => func(t1, t2);
    }

    public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
    {
        CheckNull(func, nameof(func));
        return t1 => t2 => t3 => func(t1, t2, t3);
    }

    public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curry<T1, T2, T3, T4, TResult>(
        this Func<T1, T2, T3, T4, TResult> func)
    {
        CheckNull(func, nameof(func));
        return t1 => t2 => t3 => t4 => func(t1, t2, t3, t4);
    }

    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> Curry<T1, T2, T3, T4, T5, TResult>(
        this Func<T1, T2, T3, T4, T5, TResult> func)
    {
        CheckNull(func, nameof(func));
        return t1 => t2 => t3 => t4 => t5 => func(t1, t2, t3, t4, t5);
    }

    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, TResult>>>>>> Curry<T1, T2, T3, T4, T5, T6, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, TResult> func)
    {
        CheckNull(func, nameof(func));
        return t1 => t2 => t3 => t4 => t5 => t6 => func(t1, t2, t3, t4, t5, t6);
    }

    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, TResult>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
    {
        CheckNull(func, nameof(func));
        return t1 => t2 => t3 => t4 => t5 => t6 => t7 => func(t1, t2, t3, t4, t5, t6, t7);
    }

    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, TResult>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
    {
        CheckNull(func, nameof(func));
        return t1 => t2 => t3 => t4 => t5 => t6 => t7 => t8 => func(t1, t2, t3, t4, t5, t6, t7, t8);
    }
}
