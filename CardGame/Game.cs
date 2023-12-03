// Game.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class Game
{
    private List<Player> players;
    private List<Karta> deck;
    private static Random random = new Random();

    public Game(int numPlayers = 2)
    {
        players = new List<Player>();
        deck = GenerateDeck();

        // Создаем игроков
        for (int i = 0; i < numPlayers; i++)
        {
            players.Add(new Player());
        }

        // Перетасовываем колоду
        ShuffleDeck();

        // Раздаем карты игрокам
        DealCards();
    }

    private List<Karta> GenerateDeck()
    {
        List<string> suits = new List<string> { "Черви", "Бубны", "Крести", "Пики" };
        List<string> ranks = new List<string> { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

        return suits.SelectMany(suit => ranks.Select(rank => new Karta(suit, rank))).ToList();
    }

    private void ShuffleDeck()
    {
        deck = deck.OrderBy(card => random.Next()).ToList();
    }

    private void DealCards()
    {
        int numPlayers = players.Count;
        int cardsPerPlayer = deck.Count / numPlayers;

        for (int i = 0; i < numPlayers; i++)
        {
            players[i].Cards.AddRange(deck.GetRange(i * cardsPerPlayer, cardsPerPlayer));
        }
    }

    public void PlayGame()
    {
        while (players.Any(player => player.Cards.Count < deck.Count))
        {
            List<Karta> cardsInPlay = players.Select(player => player.Cards.First()).ToList();
            int maxIndex = cardsInPlay.IndexOf(cardsInPlay.Max());

            // Перемещаем карты в конец колоды победителя
            players[maxIndex].Cards.AddRange(cardsInPlay);
            players.ForEach(player => player.Cards.RemoveAt(0));
        }

        // Определяем победителя
        int winnerIndex = players.FindIndex(player => player.Cards.Count == deck.Count);
        Console.WriteLine($"Игрок {winnerIndex + 1} победил!");
    }

    public List<Player> Players
    {
        get { return players; }
    }
}
