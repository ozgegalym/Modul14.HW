// KartaComparer.cs
using System;
using System.Collections.Generic;

public class KartaComparer : IComparer<Karta?>
{
    public int Compare(Karta? x, Karta? y)
    {
        if (x == null && y == null)
        {
            return 0;
        }

        if (x == null)
        {
            return -1;
        }

        if (y == null)
        {
            return 1;
        }

        // Сравниваем масть
        int suitComparison = string.Compare(x.Suit, y.Suit, StringComparison.Ordinal);
        if (suitComparison != 0)
        {
            return suitComparison;
        }

        // Сравниваем ранги как строки
        return string.Compare(x.Rank, y.Rank, StringComparison.Ordinal);
    }
}
