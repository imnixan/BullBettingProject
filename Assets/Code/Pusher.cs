using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Pusher : MonoBehaviour
{
    [SerializeField]
    private LeaderChecker leader;

    [SerializeField]
    private HorseRun[] runners;

    private Image currentRunner;

    private List<int> runnersNums = new List<int>();
    private int currentRunnerIndex;
    private RectTransform rt;

    public void StartRace()
    {
        rt = GetComponent<RectTransform>();
        currentRunner = GetComponent<Image>();
        foreach (var runner in runners)
        {
            runnersNums.Add(runner.horseNumber);
        }
        rt.DOAnchorPosX(-78, 0.4f).Play();
        //StartCoroutine(PushChaser());
    }

    public void Push()
    {
        StopAllCoroutines();
        foreach (var runner in runners)
        {
            if (runner.horseNumber == currentRunnerIndex)
            {
                runner.Rush(leader.colors[currentRunnerIndex]);
                break;
            }
        }
        StartCoroutine(PushChaser());
    }

    private void HideButton()
    {
        //GetComponentInChildren<Button>().interactable = false;
        //rt.DOAnchorPosX(500, 0.4f).Play();
    }

    IEnumerator PushChaser()
    {
        while (true)
        {
            currentRunnerIndex = runnersNums[Random.Range(0, runnersNums.Count)];
            currentRunner.color = leader.colors[currentRunnerIndex];
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
    }

    private void OnEnable()
    {
        BgMoving.RaceFinished += HideButton;
    }

    private void OnDisable()
    {
        BgMoving.RaceFinished -= HideButton;
    }
}
