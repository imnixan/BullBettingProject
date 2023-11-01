using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class BgMoving : MonoBehaviour
{
    public static event UnityAction RaceFinished;

    [SerializeField]
    private float raceTime;

    private void Start()
    {
        var rt = GetComponent<RectTransform>();
        //rt.pivot = new Vector2(1, 0);
        var seq = DOTween.Sequence();
        seq.Append(rt.DOAnchorMax(new Vector2(1, 0), raceTime))
            .Join(rt.DOAnchorMin(new Vector2(1, 0), raceTime))
            .Join(rt.DOPivotX(1, raceTime))
            .AppendCallback(() =>
            {
                RaceFinished?.Invoke();
            })
            .Restart();
        //rt.DOAnchorPosX(0, raceTime).Play();
    }
}
