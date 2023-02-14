using Domain;
using Microsoft.Win32.SafeHandles;

namespace Paupus;

public class CardReader
{
    public static void ReadCards(string csvPath, string outputPath)
    {
        StreamReader reader = new(csvPath);
        StreamWriter writer = new(outputPath);

        try
        {
            do
            {
                string? line = reader.ReadLine();
                if (line != null && !line.Contains(Common.CSV_SEPERATOR_STRING_DECLARATION) && !line.Contains(Common.CSV_HEADER_LINE))
                {
                    Console.WriteLine(line); //where we do the transform/storing
                    //extract useful info (quantity + name)
                    //transform/mutate to a single string
                    //Write to text file
                    //open text file
                }
            } while (!reader.EndOfStream);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}