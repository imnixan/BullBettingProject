using UnityEngine;

using UnityEngine.UI;

public class RunnersSetter : MonoBehaviour
{
    [SerializeField]
    private HorseRun[] runners;

    [SerializeField]
    private Pusher pusher;

    [SerializeField]
    private AudioClip bell,
        horses;

    private CrossSceneData crossSceneData;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        crossSceneData = FindAnyObjectByType<CrossSceneData>();
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            AudioSource.PlayClipAtPoint(bell, Vector2.zero);
            AudioSource.PlayClipAtPoint(horses, Vector2.zero);
        }
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
