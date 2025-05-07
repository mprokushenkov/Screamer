using static Bstm.Functional.Guard;

namespace Bstm.Functional;

public static class PartialApplication
{
    public static Func<TResult> Apply<T1, TResult>(this Func<T1, TResult> func, T1 t1)
    {
        CheckNull(func, nameof(func));
        return () => func(t1);
    }

    public static Func<T2, TResult> Apply<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 t1)
    {
        CheckNull(func, nameof(func));
        return (t2) => func(t1, t2);
    }

    public static Func<T2, T3, TResult> Apply<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 t1)
    {
        CheckNull(func, nameof(func));
        return (t2, t3) => func(t1, t2, t3);
    }

    public static Func<T2, T3, T4, TResult> Apply<T1, T2, T3, T4, TResult>(
        this Func<T1, T2, T3, T4, TResult> func, T1 t1)
    {
        CheckNull(func, nameof(func));
        return (t2, t3, t4) => func(t1, t2, t3, t4);
    }

    public static Func<T2, T3, T4, T5, TResult> Apply<T1, T2, T3, T4, T5, TResult>(
        this Func<T1, T2, T3, T4, T5, TResult> func, T1 t1)
    {
        CheckNull(func, nameof(func));
        return (t2, t3, t4, t5) => func(t1, t2, t3, t4, t5);
    }

    public static Func<T2, T3, T4, T5, T6, TResult> Apply<T1, T2, T3, T4, T5, T6, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, TResult> func, T1 t1)
    {
        CheckNull(func, nameof(func));
        return (t2, t3, t4, t5, t6) => func(t1, t2, t3, t4, t5, t6);
    }

    public static Func<T2, T3, T4, T5, T6, T7, TResult> Apply<T1, T2, T3, T4, T5, T6, T7, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T1 t1)
    {
        CheckNull(func, nameof(func));
        return (t2, t3, t4, t5, t6, t7) => func(t1, t2, t3, t4, t5, t6, t7);
    }

    public static Func<T2, T3, T4, T5, T6, T7, T8, TResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T1 t1)
    {
        CheckNull(func, nameof(func));
        return (t2, t3, t4, t5, t6, t7, t8) => func(t1, t2, t3, t4, t5, t6, t7, t8);
    }
}
