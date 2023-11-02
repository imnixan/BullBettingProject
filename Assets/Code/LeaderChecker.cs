using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderChecker : MonoBehaviour
{
    [SerializeField]
    public Color[] colors;

    [SerializeField]
    private Image leaderColor,
        betColor;

    [SerializeField]
    private TextMeshProUGUI bet,
        prize;

    [SerializeField]
    private HorseRun[] runners;

    private void Update()
    {
        CheckLeader();
    }

    private void Start()
    {
        bet.text = PlayerPrefs.GetInt("PlayerBet").ToString();
        prize.text = PlayerPrefs.GetInt("PlayerPrize").ToString();
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
        betColor.color = colors[PlayerPrefs.GetInt("PlayerBetHorse")];
    }
}
