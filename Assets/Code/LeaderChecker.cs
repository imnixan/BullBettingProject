using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LeaderChecker : MonoBehaviour
{
    [SerializeField]
    public Color[] colors;

    [SerializeField]
    private Image leaderColor;

    [SerializeField]
    private HorseRun[] runners;

    private void Update()
    {
        CheckLeader();
    }

    private void CheckLeader()
    {
        int leaderIndex = 0;
        float leaderX = -100;
        for (int i = 0; i < runners.Length; i++)
        {
            if (leaderX < runners[i].transform.position.x)
            {
                leaderX = runners[i].transform.position.x;
                leaderIndex = i;
            }
        }
        leaderColor.color = colors[runners[leaderIndex].horseNumber];
    }
}
