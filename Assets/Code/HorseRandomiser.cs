using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HorseRandomiser : MonoBehaviour
{
    [SerializeField]
    private CrossSceneData crossSceneData;

    [SerializeField]
    private TextMeshProUGUI[] names;

    [SerializeField]
    private Image[] horseColorsIcons;

    [SerializeField]
    private TextMeshProUGUI oddsText,
        betText,
        balanceText;

    [SerializeField]
    private Sprite choosed,
        unchoosed;

    [SerializeField]
    private LobbyBg bg;

    [SerializeField]
    private Color[] colors;

    private Dictionary<int, int> buttonChoose = new Dictionary<int, int>();
    private int bet;

    [SerializeField]
    private Button[] buttons;
    private int playerBalance;

    private bool chosed;

    private void Awake()
    {
        int[] riders = new int[] { 0, 1, 2, 3, 4, 5 };
        riders.Shuffle();
        int[] ridersForRace = new int[4];
        Array.Copy(riders, ridersForRace, 4);

        crossSceneData.Init(ridersForRace);
        InitBetting(ridersForRace);
        RebuildButtons(-1);
        for (int i = 0; i < ridersForRace.Length; i++)
        {
            horseColorsIcons[i].color = colors[ridersForRace[i]];
            names[i].text = StaticData.horsesName[ridersForRace[i]];
            names[i].color = colors[ridersForRace[i]];
        }
        playerBalance = Mathf.Max(100, PlayerPrefs.GetInt("PlayerBalance", 3000));
        balanceText.text = playerBalance.ToString();
        bet = 100;
    }

    private void InitBetting(int[] horses)
    {
        buttonChoose.Add(0, horses[0]);
        buttonChoose.Add(1, horses[1]);
        buttonChoose.Add(2, horses[2]);
        buttonChoose.Add(3, horses[3]);
    }

    public void ChooseHorse(int id)
    {
        if (bet > 0)
        {
            chosed = true;
            PlayerPrefs.SetInt("PlayerBetHorse", buttonChoose[id]);
            PlayerPrefs.Save();
            oddsText.text = StaticData.odds[buttonChoose[id]].ToString();
            float odds = StaticData.odds[buttonChoose[id]];
            PlayerPrefs.SetInt("PlayerPrize", Mathf.RoundToInt(odds * bet));
            RebuildButtons(id);
        }
    }

    private void RebuildButtons(int id)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == id)
            {
                buttons[i].image.sprite = choosed;
            }
            else
            {
                buttons[i].image.sprite = unchoosed;
            }
        }
    }

    public void Upbet()
    {
        bet += 100;
        if (bet > playerBalance)
        {
            bet = playerBalance;
        }
        betText.text = bet.ToString();
    }

    public void DownBet()
    {
        bet -= 100;
        if (bet < 0)
        {
            bet = 0;
        }
        betText.text = bet.ToString();
    }

    public void StartGame()
    {
        if (bet > 0 && chosed)
        {
            PlayerPrefs.SetInt("PlayerBet", bet);
            PlayerPrefs.SetInt("PlayerBalance", playerBalance - bet);
            PlayerPrefs.Save();
            bg.StartGame();
        }
    }
}
