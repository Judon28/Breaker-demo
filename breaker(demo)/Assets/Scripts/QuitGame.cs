using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void soundButton()
    {
        SceneManager.LoadScene("Music");
    }

    public void Main()
    {
        SceneManager.LoadScene("Main");
    }
}


