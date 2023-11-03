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
    private AudioClip stone,
        puffSound;

    [SerializeField]
    private GameObject puffPRef;

    [SerializeField]
    private Transform puffOne,
        puffTwo;

    private FingerLobby finger;

    void Start()
    {
        finger = FindAnyObjectByType<FingerLobby>();
        Screen.orientation = ScreenOrientation.Portrait;
        Sequence seq = DOTween.Sequence();
        seq.Append(nightBg.DOColor(new Color(0, 0, 0, 0), 0.5f))
            .AppendCallback(() =>
            {
                if (PlayerPrefs.GetInt("Sound", 1) == 1)
                {
                    AudioSource.PlayClipAtPoint(stone, Vector2.zero);
                }
            })
            .Append(windowBot.DOAnchorPosY(0, 0.5f))
            .Append(window.DOAnchorPosY(0, 0.5f))
            .AppendCallback(() =>
            {
                Instantiate(puffPRef, puffOne.position, new Quaternion());
                Instantiate(puffPRef, puffTwo.position, new Quaternion());
                if (PlayerPrefs.GetInt("Sound", 1) == 1)
                {
                    AudioSource.PlayClipAtPoint(puffSound, Vector2.zero);
                }
            })
            .AppendInterval(1f)
            .AppendCallback(() =>
            {
                finger.ShowHorseBet();
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
