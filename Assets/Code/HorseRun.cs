using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using DG.Tweening;

public class HorseRun : MonoBehaviour
{
    private Sprite[] animList;

    private Image image;

    [SerializeField]
    private int frame;

    [SerializeField]
    private float runSpeed = 1;

    [SerializeField]
    private float framesPerSecond;

    private RectTransform rt;
    public int horseNumber;
    private bool onMove;
    private Sequence race,
        final;

    public void Init(Sprite[] animList, int horseNumber)
    {
        rt = GetComponent<RectTransform>();
        this.animList = animList;
        image = GetComponent<Image>();
        frame = Random.Range(0, animList.Length);
        image.sprite = animList[frame];
        this.horseNumber = horseNumber;
    }

    public void StartRace()
    {
        onMove = true;
        StartCoroutine(Run());
        race = DOTween.Sequence();
        race.Append(rt.DOAnchorPosX(Random.Range(700, 1300), 3))
            .AppendCallback(() =>
            {
                onMove = false;
            })
            .Restart();
    }

    IEnumerator Run()
    {
        while (true)
        {
            frame++;
            if (frame >= animList.Length)
            {
                frame = 0;
            }
            image.sprite = animList[frame];
            image.SetNativeSize();
            yield return new WaitForSeconds((1 / framesPerSecond) / runSpeed);
            if (Random.value > 0.65f && !onMove)
            {
                onMove = true;
                race = DOTween.Sequence();
                race.Append(
                        rt.DOAnchorPosX(
                            rt.anchoredPosition.x + Random.Range(-450, 451),
                            Random.Range(2, 5)
                        )
                    )
                    .AppendCallback(() =>
                    {
                        onMove = false;
                    })
                    .Restart();
            }
        }
    }

    public void Rush()
    {
        onMove = true;
        race = DOTween.Sequence();
        race.Append(rt.DOAnchorPosX(rt.anchoredPosition.x + 250, Random.Range(1, 4)))
            .AppendCallback(() =>
            {
                onMove = false;
            })
            .Restart();
    }

    private void StopRun()
    {
        runSpeed = 1.2f;
        race.Kill();
        onMove = true;
        final = DOTween.Sequence();
        final.Append(rt.DOAnchorPosX(10000, 20)).AppendCallback(StopAllCoroutines).Restart();
    }

    private void OnEnable()
    {
        BgMoving.RaceFinished += StopRun;
    }

    private void OnDisable()
    {
        BgMoving.RaceFinished -= StopRun;
    }
}
