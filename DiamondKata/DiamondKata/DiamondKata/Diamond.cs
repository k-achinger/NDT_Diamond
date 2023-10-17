namespace DiamondKata;

public static class Diamond
{
    public static string WriteToString(char letter)
    {
        var writer = new StringWriter();
        WriteTo(letter, writer);
        return writer.ToString();
    }

    public static void WriteTo(char letter, TextWriter writer)
    {
        if (letter is not (>= 'A' and <= 'Z' or >= 'a' and <= 'z'))
            throw new ArgumentException("The character must be a latin letter.", nameof(letter));

        var a = char.IsUpper(letter) ? 'A' : 'a';
        var size = 2 * (letter - a) + 1;

        WriteTo(size, writer);
    }
    
    private static void WriteTo(int size, TextWriter writer)
    {
        for (var i = 0; i < size; i++)
        {
            var letterIdx = i <= size / 2 ? i : size - i - 1;
            var letter = (char)('A' + letterIdx);

            for (var j = 0; j < size; j++)
            {
                if (j == size / 2 - letterIdx || j == size / 2 + letterIdx)
                    writer.Write(letter);
                else
                    writer.Write(' ');
            }

            writer.WriteLine();
        }
    }
}