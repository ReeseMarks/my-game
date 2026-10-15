using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HudManager hudManager;
    public int sadGuyGoal = 4;
    public bool gameWon = false;
    public GameObject victoryPanel;

    public void CheckWinCondition()
    {
        if(hudManager.sadGuyCount >= sadGuyGoal && !gameWon)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        gameWon = true;
        victoryPanel.SetActive(true);
        //PlayerMovement moveSpeed = 0f;
        //PlayerMovement rotationSpeed = 0f;
        Time.timeScale = 0f;
        Debug.Log("You win!");
    }
}
