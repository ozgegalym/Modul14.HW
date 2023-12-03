// Karta.cs
public class Karta : IComparable<Karta>
{
    public string Suit { get; set; }
    public string Rank { get; set; }

    public Karta(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
    }

    // Реализация IComparable для сравнения карт
    public int CompareTo(Karta other)
    {
        if (other == null) return 1;

        // Сначала сравниваем масть
        int suitComparison = string.Compare(Suit, other.Suit, StringComparison.Ordinal);
        if (suitComparison != 0)
        {
            return suitComparison;
        }

        // Затем сравниваем ранг
        if (int.TryParse(Rank, out int thisRank) && int.TryParse(other.Rank, out int otherRank))
        {
            return thisRank.CompareTo(otherRank);
        }

        // Если ранги не являются числами, сравниваем их как строки
        return string.Compare(Rank, other.Rank, StringComparison.Ordinal);
    }
}
