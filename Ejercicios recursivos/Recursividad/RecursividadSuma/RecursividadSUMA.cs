namespace Recursividad;

public class RecursividadSUMA
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Suma(5));
        Console.ReadLine();
    }

    public static int Suma(int n)
    {
        if (n == 1)
        {
            return n;
        }
        else
        {
            return n + Suma(n - 1);
        }
    }
}