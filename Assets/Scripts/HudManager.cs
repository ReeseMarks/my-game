using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    public int sadGuyCount = 0;
    public TextMeshProUGUI sadGuyText;
    public GameManager gameManager;

    public void UpdateHUD()
    {
        sadGuyText.text = "Sad Guys: " + sadGuyCount;
    }

    private void Start()
    {
        UpdateHUD();
    }

    public void CollectSadGuy()
    {
        sadGuyCount++;
        UpdateHUD();
        gameManager.CheckWinCondition();
    }
}
