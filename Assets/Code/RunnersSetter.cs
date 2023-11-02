using UnityEngine;

using UnityEngine.UI;

public class RunnersSetter : MonoBehaviour
{
    [SerializeField]
    private HorseRun[] runners;

    private void Start()
    {
        CrossSceneData crossSceneData = FindAnyObjectByType<CrossSceneData>();
        for (int i = 0; i < runners.Length; i++)
        {
            runners[i].Init(crossSceneData.runnersInRaceSprites[i], crossSceneData.runnersList[i]);
            runners[i].StartRace();
        }
    }
}
