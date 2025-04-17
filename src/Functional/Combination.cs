using static Bstm.Functional.Guard;

namespace Bstm.Functional;

public static class Combination
{
    public static Func<TR2> Combine<TR1, TR2>(this Func<TR1> f, Func<TR1, TR2> g)
    {
        CheckNull(f);
        CheckNull(g);
        return () => g(f());
    }

    public static Func<T1, TR2> Combine<T1, TR1, TR2>(this Func<T1, TR1> f, Func<TR1, TR2> g)
    {
        CheckNull(f);
        CheckNull(g);
        return t1 => g(f(t1));
    }

    public static Func<T1, T2, TR2> Combine<T1, T2, TR1, TR2>(this Func<T1, T2, TR1> f, Func<TR1, TR2> g)
    {
        CheckNull(f);
        CheckNull(g);
        return (t1, t2) => g(f(t1, t2));
    }

    public static Func<T1, T2, T3, TR2> Combine<T1, T2, T3, TR1, TR2>(this Func<T1, T2, T3, TR1> f, Func<TR1, TR2> g)
    {
        CheckNull(f);
        CheckNull(g);
        return (t1, t2, t3) => g(f(t1, t2, t3));
    }

    public static Func<T1, T2, T3, T4, TR2> Combine<T1, T2, T3, T4, TR1, TR2>(
        this Func<T1, T2, T3, T4, TR1> f, Func<TR1, TR2> g)
    {
        CheckNull(f);
        CheckNull(g);
        return (t1, t2, t3, t4) => g(f(t1, t2, t3, t4));
    }

    public static Func<T1, T2, T3, T4, T5, TR2> Combine<T1, T2, T3, T4, T5, TR1, TR2>(
        this Func<T1, T2, T3, T4, T5, TR1> f, Func<TR1, TR2> g)
    {
        CheckNull(f);
        CheckNull(g);
        return (t1, t2, t3, t4, t5) => g(f(t1, t2, t3, t4, t5));
    }

    public static Func<T1, T2, T3, T4, T5, T6, TR2> Combine<T1, T2, T3, T4, T5, T6, TR1, TR2>(
        this Func<T1, T2, T3, T4, T5, T6, TR1> f, Func<TR1, TR2> g)
    {
        CheckNull(f);
        CheckNull(g);
        return (t1, t2, t3, t4, t5, t6) => g(f(t1, t2, t3, t4, t5, t6));
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, TR2> Combine<T1, T2, T3, T4, T5, T6, T7, TR1, TR2>(
        this Func<T1, T2, T3, T4, T5, T6, T7, TR1> f, Func<TR1, TR2> g)
    {
        CheckNull(f);
        CheckNull(g);
        return (t1, t2, t3, t4, t5, t6, t7) => g(f(t1, t2, t3, t4, t5, t6, t7));
    }

    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TR2> Combine<T1, T2, T3, T4, T5, T6, T7, T8, TR1, TR2>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, TR1> f, Func<TR1, TR2> g)
    {
        CheckNull(f);
        CheckNull(g);
        return (t1, t2, t3, t4, t5, t6, t7, t8) => g(f(t1, t2, t3, t4, t5, t6, t7, t8));
    }
}
