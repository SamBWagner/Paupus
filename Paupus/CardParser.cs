using Paupus.Models;

namespace Paupus;

public class CardParser
{
    public static async void ConvertDragonShieldCsvToSearchableText(StreamReader inputStream, string outputLocation)
    {
        //TODO: output to file
        while (!inputStream.EndOfStream)
        {
            await using StreamWriter file = new(outputLocation);
            DragonShieldCard? parsedCard = ParseLine(inputStream.ReadLine());
            if (parsedCard is null) continue;
            await file.WriteLineAsync($"{parsedCard.Quantity} {parsedCard.CardName}");
        }
    }

    public static DragonShieldCard? ParseLine(string? inputLine)
    {
        if (string.IsNullOrEmpty(inputLine)) return null;
        List<string> tempStorage = new();

        while(!string.IsNullOrEmpty(inputLine))
        {
            tempStorage.Add(GetFirstElementOfCsv(inputLine));
            inputLine = removeFirstElementFromCsvLine(inputLine);
        }
        
        DragonShieldCard outputDragonShieldCard = new()
        {
            FolderName = tempStorage[0],
            Quantity = int.Parse(tempStorage[1]),
            TradeQuantity = int.Parse(tempStorage[2]),
            CardName = tempStorage[3],
            SetCode = tempStorage[4],
            SetName = tempStorage[5],
            CardNumber = int.Parse(tempStorage[6]),
            Condition = tempStorage[7],
            Printing = tempStorage[8],
            Language = tempStorage[9],
            PriceBought = double.Parse(tempStorage[10]),
            DateBought = DateTime.Parse(tempStorage[11]),
            Low = double.Parse(tempStorage[12]),
            Mid = double.Parse(tempStorage[13]),
            Market = double.Parse(tempStorage[14])
        };

        return outputDragonShieldCard;
    }

    private static string GetFirstElementOfCsv(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        if (input[0] == '"')
        {
            int nextSeparator = input.IndexOf("\",", StringComparison.Ordinal);

            Console.WriteLine(input.Substring(1, nextSeparator - 1));
            return input.Substring(1, nextSeparator - 1);
        }
        
        int indexOfComma = input.IndexOf(",", StringComparison.Ordinal);
        if (indexOfComma == -1)
        {
            Console.WriteLine(input.Substring(0));
            return input.Substring(0);
        }

        Console.WriteLine(input.Substring(0, indexOfComma));
        return input.Substring(0, indexOfComma);
    }

    static string removeFirstElementFromCsvLine(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        
        if (input[0] == '"')
        {
            int nextSeparator = input.IndexOf("\",", StringComparison.Ordinal) + 2;
            return input.Substring(nextSeparator);
        }
        
        string[] csvSections = input.Split(",");
        return string.Join("," ,csvSections.Skip(1).ToArray());
    }
    
}