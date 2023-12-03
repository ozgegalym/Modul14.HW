// Program.cs
class Program
{
    static void Main()
    {
        // Создаем объект игры с двумя игроками
        Game game = new Game();

        // Начинаем игру
        game.PlayGame();

        // Выводим карты у каждого игрока
        for (int i = 0; i < game.Players.Count; i++)
        {
            Console.WriteLine($"Игрок {i + 1}:");
            game.Players[i].ShowCards();
        }
    }
}
