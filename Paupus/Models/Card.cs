namespace Paupus.Models;

public class Card
{
    public string CardName { get; set; }
    public int Quantity { get; set; }
    public string SetCode { get; set; }
    public string SetName { get; set; }
    public string CardNumber { get; set; }
    public string Printing { get; set; }
    public double? Price { get; set; }

    public Card(string cardName, 
        int quantity, 
        string setCode, 
        string setName, 
        string cardNumber,
        string printing)
    {
        CardName = cardName;
        Quantity = quantity;
        SetCode = setCode;
        SetName = setName;
        CardNumber = cardNumber;
        Printing = printing;
    }
}