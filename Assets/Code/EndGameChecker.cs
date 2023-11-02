using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameChecker : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI winnerName,
        bet,
        prize;

    [SerializeField]
    private LeaderChecker leader;

    [SerializeField]
    private RectTransform winWindow,
        bar;

    [SerializeField]
    private Transform finishLine;

    [SerializeField]
    private ParticleSystem explode;
    private RectTransform rt;

    private bool finished;

    private void OnEnable()
    {
        HorseRun.HorseFinished += ShowEnd;
        rt = GetComponent<RectTransform>();
    }

    private void ShowEnd(int finishedRunner)
    {
        Sequence seq = DOTween
            .Sequence()
            .AppendCallback(() =>
            {
                ParticleSystem ps = Instantiate(explode, finishLine.position, new Quaternion());
                var main = ps.main;
                main.startColor = Random.ColorHSV();
            })
            .AppendInterval(0.3f)
            .AppendCallback(() =>
            {
                ParticleSystem ps = Instantiate(explode, finishLine.position, new Quaternion());
                var main = ps.main;
                main.startColor = Random.ColorHSV();
            })
            .AppendInterval(0.3f)
            .AppendCallback(() =>
            {
                ParticleSystem ps = Instantiate(explode, finishLine.position, new Quaternion());
                var main = ps.main;
                main.startColor = Random.ColorHSV();
            });
        seq.Restart();

        HorseRun.HorseFinished -= ShowEnd;
        finished = true;
        rt.DOAnchorPosY(0, 0.5f).Play();
        int playerBetHorse = PlayerPrefs.GetInt("PlayerBetHorse");
        winnerName.text = StaticData.horsesName[finishedRunner];
        winnerName.color = leader.colors[finishedRunner];
        bet.text = PlayerPrefs.GetInt("PlayerBet").ToString();
        bet.color = leader.colors[PlayerPrefs.GetInt("PlayerBetHorse")];
        if (playerBetHorse == finishedRunner)
        {
            winWindow.DOAnchorPosY(0, 1.5f).Play();
            prize.text = (PlayerPrefs.GetInt("PlayerPrize")).ToString();
            PlayerPrefs.SetInt(
                "PlayerBalance",
                PlayerPrefs.GetInt("PlayerBalance")
                    + PlayerPrefs.GetInt("PlayerPrize")
                    + PlayerPrefs.GetInt("PlayerBet")
            );
        }
        bar.DOAnchorPosY(1000, 0.5f).Play();
    }

    private void OnDisable()
    {
        if (!finished)
        {
            HorseRun.HorseFinished -= ShowEnd;
        }
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
