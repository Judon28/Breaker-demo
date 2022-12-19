using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public void Home()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void Reset()
    {
        SceneManager.LoadScene("level1");
        //Time.timeScale = 1f;
    }
}
