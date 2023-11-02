using UnityEngine;

using UnityEngine.UI;

public class RunnersSetter : MonoBehaviour
{
    [SerializeField]
    private HorseRun[] runners;

    [SerializeField]
    private Pusher pusher;

    private CrossSceneData crossSceneData;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        crossSceneData = FindAnyObjectByType<CrossSceneData>();
        for (int i = 0; i < runners.Length; i++)
        {
            runners[i].Init(crossSceneData.runnersInRaceSprites[i], crossSceneData.runnersList[i]);
            runners[i].StartRace();
        }
        pusher.StartRace();
    }

    private void OnDisable()
    {
        Destroy(crossSceneData.gameObject);
    }
}
