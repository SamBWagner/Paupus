using System.Data;
using Paupus.Models;

namespace Paupus;

public class CardParser
{
    public static async Task<List<Card>> GetFromDragonShieldCsv(StreamReader inputStream)
    {
        List<Card> cards = new();

        while (!inputStream.EndOfStream)
        {
            DragonShieldCard? dragonShieldCard = ParseLine(await inputStream.ReadLineAsync());
            if (dragonShieldCard is not null)
            {
                cards.Add(dragonShieldCard.ToCard());
            }
        }

        if (cards.Count < 1)
        {
            throw new ConstraintException($"A List with no Cards is not an acceptable value to return from {nameof(GetFirstElementOfCsv)}()");
        } 
            
        return cards;
    }
    
    public static async void ConvertDragonShieldCsvToSearchableText(StreamReader inputStream, StreamWriter outputWriter)
    {
        while (!inputStream.EndOfStream)
        {
            DragonShieldCard? parsedCard = ParseLine(await inputStream.ReadLineAsync());
            if (parsedCard is null) continue;
            await outputWriter.WriteLineAsync($"{parsedCard.Quantity} {parsedCard.CardName}");
        }
    }

    private static DragonShieldCard? ParseLine(string? inputLine)
    {
        if (string.IsNullOrEmpty(inputLine)) return null;
        if (inputLine.Contains(Common.CSV_HEADER_LINE) || 
            inputLine.Contains(Common.CSV_SEPERATOR_STRING_DECLARATION)) return null;
        List<string> tempStorage = new();

        while(inputLine is not null)
        {
            tempStorage.Add(GetFirstElementOfCsv(inputLine));
            inputLine = RemoveFirstElementFromCsvLine(inputLine);
        }

        DragonShieldCard outputDragonShieldCard = new()
        {
            FolderName = tempStorage[0],
            Quantity = int.Parse(tempStorage[1]),
            TradeQuantity = int.Parse(tempStorage[2]),
            CardName = tempStorage[3],
            SetCode = tempStorage[4],
            SetName = tempStorage[5],
            CardNumber = tempStorage[6],
            Condition = tempStorage[7],
            Printing = tempStorage[8],
            Language = tempStorage[9],
            PriceBought = double.Parse(!string.IsNullOrEmpty(tempStorage[10]) ? tempStorage[10] : "0"),
            DateBought = DateTime.Parse(!string.IsNullOrEmpty(tempStorage[11]) ? tempStorage[11] : null),
            Low = double.Parse(!string.IsNullOrEmpty(tempStorage[12]) ? tempStorage[12] : "0"),
            Mid = double.Parse(!string.IsNullOrEmpty(tempStorage[13]) ? tempStorage[13] : "0"),
            Market = double.Parse(!string.IsNullOrEmpty(tempStorage[14]) ? tempStorage[14] : "0")
        };

        return outputDragonShieldCard;
    }

    private static string GetFirstElementOfCsv(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        if (input[0] == '"')
        {
            int nextSeparator = input.IndexOf("\",", StringComparison.Ordinal);

            return input.Substring(1, nextSeparator - 1);
        }
        
        int indexOfComma = input.IndexOf(",", StringComparison.Ordinal);
        if (indexOfComma == -1)
        {
            return input.Substring(0);
        }

        return input.Substring(0, indexOfComma);
    }

    private static string? RemoveFirstElementFromCsvLine(string input)
    {
        if (string.IsNullOrEmpty(input)) return null;
        
        if (input[0] == '"')
        {
            int nextSeparator = input.IndexOf("\",", StringComparison.Ordinal) + 2;
            return input.Substring(nextSeparator);
        }
        
        string[] csvSections = input.Split(",");
        return string.Join("," ,csvSections.Skip(1).ToArray());
    }
    
}