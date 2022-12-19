using UnityEngine;
using UnityEngine.SceneManagement;

public class levelPassed : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("Win");
    }
    
    public void Home()
    {
        SceneManager.LoadScene("Main");
    }

    public void Reset()
    {
        SceneManager.LoadScene("level1");
        
    }
}
