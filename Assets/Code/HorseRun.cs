using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.Assertions.Must;

public class HorseRun : MonoBehaviour
{
    public static event UnityAction<int> HorseFinished;
    private Sprite[] animList;

    private Image image;

    [SerializeField]
    private int frame;

    [SerializeField]
    private Transform finishLine;

    [SerializeField]
    private float runSpeed = 1;

    [SerializeField]
    private float framesPerSecond;

    private RectTransform rt;
    public int horseNumber;
    private bool onMove;
    private bool onFinishLine;
    private Sequence race,
        final;
    private bool finished;
    private ParticleSystem fire;

    public void Init(Sprite[] animList, int horseNumber)
    {
        rt = GetComponent<RectTransform>();
        this.animList = animList;
        image = GetComponent<Image>();
        frame = Random.Range(0, animList.Length);
        image.sprite = animList[frame];
        this.horseNumber = horseNumber;
        fire = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (transform.position.x > finishLine.position.x && !finished)
        {
            Debug.Log("finished" + horseNumber);
            HorseFinished?.Invoke(horseNumber);
            finished = true;
        }
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
                float newPos = rt.anchoredPosition.x + Random.Range(-450, 451);
                race.Append(rt.DOAnchorPosX(newPos, Random.Range(2, 5)))
                    .AppendCallback(() =>
                    {
                        onMove = false;
                    })
                    .Restart();
            }
        }
    }

    public void Rush(Color color)
    {
        if (!onFinishLine)
        {
            onMove = true;
            race.Kill();
            var main = fire.main;
            main.startColor = color;
            fire.Play();
            float newPos = rt.anchoredPosition.x + 250;
            race = DOTween.Sequence();
            race.Append(rt.DOAnchorPosX(newPos, Random.Range(1f, 3f)))
                .AppendCallback(() =>
                {
                    onMove = false;
                    fire.Stop();
                })
                .Restart();
        }
    }

    private void StopRun()
    {
        fire.Stop();
        onFinishLine = true;
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
