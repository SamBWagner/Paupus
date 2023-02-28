using Domain;

namespace Infrastructure;

public static class DragonShieldCardReader
{
    public static async void ConvertDragonShieldCsvToMtgMateText(StreamReader inputReader, string outputPath)
    {
        List<string> outputLines = new();

        try
        {
            do
            {
                string[]? lineSections = ParseCsvLine(await inputReader.ReadLineAsync());
                
                {
                    DragonShieldCard card = new()
                    {
                        FolderName = lineSections[0],
                        Quantity = int.Parse(lineSections[1]),
                        TradeQuantity = int.Parse(lineSections[2]),
                        CardName = lineSections[3],
                        SetCode = lineSections[4],
                        SetName = lineSections[5],
                        CardNumber = int.Parse(lineSections[6]),
                        Condition = lineSections[7],
                        Printing = lineSections[8],
                        Language = lineSections[9],
                        PriceBought = double.Parse(lineSections[10]),
                        DateBought = DateTime.Parse(lineSections[11]),
                        Low = double.Parse(lineSections[12]),
                        Mid = double.Parse(lineSections[13]),
                        Market = double.Parse(lineSections[14])
                    };
                    outputLines?.Add($"{card.Quantity} {card.CardName}");
                }
            } while (!inputReader.EndOfStream);

            if (outputLines is null) return;
            await File.WriteAllLinesAsync(outputPath, outputLines);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static string[]? ParseCsvLine(string? line)
    {
        if (line != null && !line.Contains(Common.CSV_SEPERATOR_STRING_DECLARATION)
                         && !line.Contains(Common.CSV_HEADER_LINE))
        {
            //TODO: parse the shit
            line.Substring();
        }
        return null;
    }
}