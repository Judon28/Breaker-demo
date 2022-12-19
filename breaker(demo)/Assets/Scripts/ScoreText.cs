using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
   public static ScoreText instance;

   public Text myScoreText;

   int score = 0;

   private void Awake()
   {
     instance = this;
   }
   
   void Start()
   {
          
     myScoreText.text = "Score: " + score.ToString();
   }

   public void updateScore()
   {
     score += 100;
     myScoreText.text = "Score: " + score.ToString();
   }



   
}


// when the score in the game manager updates, we want to update our scoretext ui