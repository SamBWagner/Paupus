namespace Paupus.Models;

public class Card
{
    public string Name { get; set; }
    public string OracleText { get; set; }
    public string Power { get; set; }
    public string Toughness { get; set; }
    public double ConvertedManaCost { get; set; }
    public string? ManaCost { get; set; }
    public string SetCode { get; set; }
    public string SetName { get; set; }
    public string CardNumber { get; set; }
    public string TypeLine { get; set; }

    public static Card ToCardFromScryfallCard(ScryFallCard inputCard)
    {
        return new Card
        {
            Name = inputCard.Name,
            OracleText = inputCard.OracleText,
            Power = inputCard.Power,
            Toughness = inputCard.Toughness,
            ConvertedManaCost = inputCard.ConvertedManaCost,
            ManaCost = inputCard.ManaCost,
            SetCode = inputCard.SetCode,
            SetName = inputCard.SetName,
            CardNumber = inputCard.CollectorNumber,
            TypeLine = inputCard.TypeLine
        };
    }
}