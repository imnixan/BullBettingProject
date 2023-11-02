using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class BgMoving : MonoBehaviour
{
    public static event UnityAction RaceFinished;

    public void FinishRace()
    {
        RaceFinished?.Invoke();
    }
}
