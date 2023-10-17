namespace DiamondKata;

public class Program
{
    public static int Main(string[] args)
    {
        if (args.Length != 1 || args[0].Length != 1)
        {
            Console.WriteLine("Single letter argument expected.");
            return 1;
        }

        try
        {
            Diamond.WriteTo(args[0][0], Console.Out);
            return 0;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return 1;
        }
    }
}