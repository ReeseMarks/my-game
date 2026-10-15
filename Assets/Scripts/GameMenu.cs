using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void PlayMain()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("levelTwo");
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("game");
        Time.timeScale = 1f;
    }
}
