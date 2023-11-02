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
    public static Dictionary<int, float> odds = new Dictionary<int, float>
    {
        { 0, 3f },
        { 1, 2.0f },
        { 2, 0.25f },
        { 3, 12.0f },
        { 4, 1.2f },
        { 5, 1.0f }
    };
}
