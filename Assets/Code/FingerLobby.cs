using UnityEngine;

public class FingerLobby : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowOdds()
    {
        animator.SetBool("ShowOdds", true);
    }

    public void ShowBet()
    {
        animator.SetBool("ShowBet", true);
    }

    public void ShowHorseBet()
    {
        animator.SetBool("ShowHorseBet", true);
    }

    public void Hide()
    {
        animator.SetBool("ShowOdds", false);
        animator.SetBool("ShowHorseBet", false);
    }
}
