// Player.cs
using System;
using System.Collections.Generic;

public class Player
{
    public List<Karta> Cards { get; set; }

    public Player()
    {
        Cards = new List<Karta>();
    }

    public void ShowCards()
    {
        Console.WriteLine("Имеющиеся карты:");
        foreach (var card in Cards)
        {
            Console.WriteLine($"{card.Rank} {card.Suit}");
        }
    }
}
