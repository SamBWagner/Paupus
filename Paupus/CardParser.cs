using Paupus.Models;

namespace Paupus;

public class CardParser
{
    public static void ConvertDragonShieldCsvToSearchableText()
    {

    }

    public static DragonShieldCard ParseLine(string inputLine)
    {
        DragonShieldCard output = new();
        string csvElement;

        while(!string.IsNullOrEmpty(inputLine))
        {
            csvElement = GetFirstElementOfCsv(inputLine);
            inputLine = removeFirstElementFromCsvLine(inputLine);
        }

        return null;
    }

    private static string GetFirstElementOfCsv(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        
        int indexOfComma = input.IndexOf(",", StringComparison.Ordinal);
        if (indexOfComma == -1)
        {
            return input.Substring(0);
        }
        
        return input.Substring(0, indexOfComma);
    }

    static string removeFirstElementFromCsvLine(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        
        string[] csvSections = input.Split(",");
        return string.Join("," ,csvSections.Skip(1).ToArray());
    }
    
}