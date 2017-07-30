using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private readonly IList<CoffeeType> coffeeSold;

    public CoffeeMachine()
    {
        this.coffeeSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold => this.coffeeSold;

    public int Coins { get; set; }

    public void BuyCoffee(string size, string type)
    {
        var coffePrice = (CoffeePrice) Enum.Parse(typeof(CoffeePrice), size);
        var coffeType = (CoffeeType) Enum.Parse(typeof(CoffeeType), type);

        if ((int) coffePrice <= this.Coins)
        {
            this.coffeeSold.Add(coffeType);
            this.Coins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        var rem = (Coin) Enum.Parse(typeof(Coin), coin);

        this.Coins += (int) rem;
    }
}
