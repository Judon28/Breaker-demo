//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
   

   public void OpenScene()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


   }
}
