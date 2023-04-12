namespace Paupus.Models;

public class DragonShieldCard
{
    public string FolderName { get; set; }
    public int Quantity { get; set; }
    public int TradeQuantity { get; set; } 
    public string CardName { get; set; }
    public string SetCode { get; set; }
    public string SetName { get; set; }
    public string CardNumber { get; set; }
    public string Condition { get; set; }
    public string Printing { get; set; }
    public string Language { get; set; }
    public double PriceBought { get; set; } 
    public DateTime? DateBought { get; set; } 
    public double Low { get; set; }
    public double Mid { get; set; }
    public double Market { get; set; }

    public Card ToCard()
    {
        return new Card
        {
            Name = CardName,
            OracleText = string.Empty,
            Power = string.Empty,
            Toughness = string.Empty,
            Cmc = -1,
            ManaCost = string.Empty,
            Quantity = Quantity,
            SetCode = SetCode,
            SetName = SetName,
            CardNumber = CardNumber

        };
    }
}