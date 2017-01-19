using System;

class Program
{
    static void Main(string[] args)
    {
        PassByValueSample();
        PassByReferenceSample();
        OutSample();
        OutSample2();
        ReturnByRefSample();
        FastAccessToArrayElements();
    }

    static ref int Get(int[] arr, int ix) => ref arr[ix];

    static void PassByValueSample()
    {
        int x = 1;
        PassByValue(x);
        Console.WriteLine($"after the invocation of {nameof(PassByValue)}, x = {x}");
    }

    static void PassByValue(int x)
    {
        x = 2;
    }

    static void PassByReferenceSample()
    {
        int x = 1;
        PassByReference(ref x);
        Console.WriteLine($"after the invocation of {nameof(PassByReference)}, x = {x}");
    }

    static void PassByReference(ref int x)
    {
        x = 2;
    }

    static void OutSample()
    {
        Out(out int x);
        Console.WriteLine($"after the invocation of {nameof(Out)}, x = {x}");
    }
    static void Out(out int x)
    {
        x = 2;
    }

    static void OutSample2()
    {
        if (int.TryParse("42", out int result))
        {
            Console.WriteLine($"the result is {result}");
        }
    }

    static void ReturnByRefSample()
    {
        ref int x1 = ref ReturnByReference();
        Console.WriteLine($"x1 after calling {nameof(ReturnByReference)}: {x1}");
        ref int x2 = ref ReturnByReference2(ref x1);
        Console.WriteLine($"x2 after calling {nameof(ReturnByReference2)}: {x2}, x1: {x1}");
    }

    static ref int ReturnByReference()
    {
        int[] arr = { 1 };
        ref int x = ref arr[0];
        return ref x;
    }

    static ref int ReturnByReference2(ref int x)
    {
        x = 2;
        return ref x;
    }

    static void FastAccessToArrayElements()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        ref int x = ref GetByIndex(arr, 2);
        x = 42;
        Console.WriteLine($"arr[2] after it was changed using a ref return: {arr[2]}");

    }

    static ref int GetByIndex(int[] list, int ix) => ref list[ix];

}