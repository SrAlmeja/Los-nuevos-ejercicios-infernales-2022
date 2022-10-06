
public class RecursividadFactorial
{
    public static void Main2(string[] args)
    {
        Console.WriteLine(Factorial(5));
        Console.ReadLine();
    }

    public static int Factorial(int n)
    {
        if (n == 1)
        {
            return n;
        }
        else
        {
            return n * (n - 1);
        }
    }
}