using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HorseRandomiser : MonoBehaviour
{
    [SerializeField]
    private CrossSceneData crossSceneData;

    private void Awake()
    {
        int[] riders = new int[] { 0, 1, 2, 3, 4, 5 };
        riders.Shuffle();
        int[] ridersForRace = new int[4];
        Array.Copy(riders, ridersForRace, 4);

        crossSceneData.Init(ridersForRace);
    }
}
