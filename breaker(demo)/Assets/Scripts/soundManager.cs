using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    private bool muted = false;
    /*void Start()
    {
        if(!PlayerPrefs.Haskey("muted"))
        {
            PlayerPrefs.GetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
    }*/

    public void muteToggle(bool muted)
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = true;
            AudioListener.pause = true;
        }

        Save();
    }

    public void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    
    public void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
