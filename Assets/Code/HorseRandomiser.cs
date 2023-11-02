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
    private Sprite choosed,
        unchoosed;

    [SerializeField]
    private Color[] colors;

    private Dictionary<int, int> buttonChoose = new Dictionary<int, int>();

    [SerializeField]
    private Button[] buttons;

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
        }
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
        PlayerPrefs.SetInt("PlayerBetHorse", buttonChoose[id]);
        PlayerPrefs.Save();
        RebuildButtons(id);
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
}
