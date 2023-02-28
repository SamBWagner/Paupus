namespace Domain;

public class DragonShieldCard
{
    public string FolderName { get; set; }
    public int Quantity { get; set; }
    public int TradeQuantity { get; set; } 
    public string CardName { get; set; }
    public string SetCode { get; set; }
    public string SetName { get; set; }
    public int CardNumber { get; set; }
    public string Condition { get; set; }
    public string Printing { get; set; }
    public string Language { get; set; }
    public double PriceBought { get; set; } 
    public DateTime DateBought { get; set; } 
    public double Low { get; set; }
    public double Mid { get; set; }
    public double Market { get; set; }
}