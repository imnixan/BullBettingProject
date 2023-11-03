using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Image soundButton,
        musicButton;

    [SerializeField]
    private Sprite[] buttons;

    [SerializeField]
    private AudioClip swapWindow;

    [SerializeField]
    private RectTransform startWindow,
        settingsWindow;

    private Sequence showSettings,
        showMenu,
        hideAll;

    private void Start()
    {
        SetBtnColors();
        Screen.orientation = ScreenOrientation.Portrait;
        Application.targetFrameRate = 300;
        showSettings = DOTween
            .Sequence()
            .Append(startWindow.DOAnchorPosX(-5000, 0.3f))
            .Append(settingsWindow.DOAnchorPosX(0, 0.3f));

        showMenu = DOTween
            .Sequence()
            .Append(startWindow.DOAnchorPosX(0, 0.3f))
            .Append(settingsWindow.DOAnchorPosX(5000, 0.3f));

        hideAll = DOTween
            .Sequence()
            .Append(startWindow.DOAnchorPosX(-5000, 0.3f))
            .Append(settingsWindow.DOAnchorPosX(5000, 0.3f))
            .AppendCallback(() =>
            {
                SceneManager.LoadScene("Lobby");
            });

        showMenu.Restart();
    }

    private void SetBtnColors()
    {
        soundButton.sprite = buttons[PlayerPrefs.GetInt("Sound", 1)];
        musicButton.sprite = buttons[PlayerPrefs.GetInt("Music", 1)];
    }

    public void ChangeButton(string button)
    {
        PlayerPrefs.SetInt(button, PlayerPrefs.GetInt(button, 1) == 1 ? 0 : 1);
        PlayerPrefs.Save();
        SetBtnColors();
    }

    public void ShowSet()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            AudioSource.PlayClipAtPoint(swapWindow, Vector2.zero);
        }
        showSettings.Restart();
    }

    public void HideSet()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            AudioSource.PlayClipAtPoint(swapWindow, Vector2.zero);
        }
        showMenu.Restart();
    }

    public void Lobby()
    {
        hideAll.Restart();
    }
}
