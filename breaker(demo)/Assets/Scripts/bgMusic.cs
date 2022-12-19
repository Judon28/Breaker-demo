using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMusic : MonoBehaviour
{
    
    private static bgMusic music;

    void Awake()
    {
        if(music == null)
        {
            music = this;
            DontDestroyOnLoad(music);

        }
        else
        {
            Destroy(gameObject);
        }

    }

}
