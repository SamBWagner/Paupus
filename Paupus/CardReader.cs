using Domain;
using Microsoft.Win32.SafeHandles;

namespace Paupus;

public class CardReader
{
    public static async void ReadCards(string csvPath, string outputPath)
    {
        StreamReader reader = new(csvPath);
        List<string> outputLines = new();

        try
        {
            do
            {
                string? line = reader.ReadLine();
                if (line != null && !line.Contains(Common.CSV_SEPERATOR_STRING_DECLARATION) && !line.Contains(Common.CSV_HEADER_LINE))
                {
                    /*
                     * Will create the full array of stuff first so that a fresh file is created
                     *
                     * Future: Change to write 1 line at a time and either flush or don't flush the existing file
                     */
                    var lineSections = line.Split(",");
                    if (outputLines != null) outputLines.Add($"{lineSections[1]} {lineSections[3]}");
                    //where we do the transform/storing
                    //extract useful info (quantity + name)
                    //transform/mutate to a single string
                    //Write to text file
                    //open text file
                }
            } while (!reader.EndOfStream);

            await File.WriteAllLinesAsync(outputPath, outputLines);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}