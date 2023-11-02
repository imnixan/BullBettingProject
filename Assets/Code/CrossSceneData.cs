using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public class CrossSceneData : MonoBehaviour
{
    public List<Sprite[]> runnersInRaceSprites;

    [SerializeField]
    private Sprite[] greenRunnerSpites,
        redRunnerSprites,
        blueRunnerSprites,
        yellowRunnerSprites,
        purpleRunnerSprites,
        seaRunnerSprites;

    public List<int> runnersList;

    public void Init(int[] runnersIndexes)
    {
        SetRunners(runnersIndexes);
    }

    private void SetRunners(int[] runnersIndexes)
    {
        var timeRunners = new List<Sprite[]>()
        {
            greenRunnerSpites,
            redRunnerSprites,
            blueRunnerSprites,
            yellowRunnerSprites,
            purpleRunnerSprites,
            seaRunnerSprites
        };

        runnersInRaceSprites = new List<Sprite[]>();
        runnersList = new List<int>();
        for (int i = 0; i < runnersIndexes.Length; i++)
        {
            runnersInRaceSprites.Add(timeRunners[runnersIndexes[i]]);
            runnersList.Add(runnersIndexes[i]);
        }
    }
}
