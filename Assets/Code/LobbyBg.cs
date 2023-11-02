using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyBg : MonoBehaviour
{
    [SerializeField]
    private Image nightBg,
        dayBg;

    [SerializeField]
    private RectTransform windowBot,
        window;

    [SerializeField]
    private GameObject puffPRef;

    [SerializeField]
    private Transform puffOne,
        puffTwo;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Sequence seq = DOTween.Sequence();
        seq.Append(nightBg.DOColor(new Color(0, 0, 0, 0), 0.5f))
            .Append(windowBot.DOAnchorPosY(0, 0.5f))
            .Append(window.DOAnchorPosY(0, 0.5f))
            .AppendCallback(() =>
            {
                Instantiate(puffPRef, puffOne.position, new Quaternion());
                Instantiate(puffPRef, puffTwo.position, new Quaternion());
            });
        seq.Restart();
    }

    public void Menu()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(window.DOAnchorPosY(5000, 0.5f))
            .Append(windowBot.DOAnchorPosY(-5000, 0.5f))
            .Append(nightBg.DOColor(Color.white, 0.5f))
            .AppendCallback(() =>
            {
                SceneManager.LoadScene("Menu");
            });
        seq.Restart();
    }

    public void StartGame()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(window.DOAnchorPosY(5000, 0.5f))
            .Append(windowBot.DOAnchorPosY(-5000, 0.5f))
            .Append(nightBg.DOColor(Color.white, 0.5f))
            .AppendCallback(() =>
            {
                SceneManager.LoadScene("HorseRide");
            });
        seq.Restart();
    }
}
