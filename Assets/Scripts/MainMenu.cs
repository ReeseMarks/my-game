using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
