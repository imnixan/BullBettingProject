using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

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

    public int horseNumber;

    public void Init(Sprite[] animList, int horseNumber)
    {
        this.animList = animList;
        image = GetComponent<Image>();
        image.sprite = animList[frame];
        this.horseNumber = horseNumber;
    }

    public void StartRace()
    {
        StartCoroutine(Run());
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
        }
    }

    private void StopRun()
    {
        StopAllCoroutines();
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
