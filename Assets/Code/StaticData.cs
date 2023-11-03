using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    public static Dictionary<int, string> horsesName = new Dictionary<int, string>
    {
        { 0, "Majesty" },
        { 1, "Flame" },
        { 2, "Dream" },
        { 3, "Serenade" },
        { 4, "Veil" },
        { 5, "Aurora" }
    };
    public static Dictionary<int, int> odds = new Dictionary<int, int>
    {
        { 0, 3 },
        { 1, 2 },
        { 2, 4 },
        { 3, 5 },
        { 4, 12 },
        { 5, 36 }
    };
}
