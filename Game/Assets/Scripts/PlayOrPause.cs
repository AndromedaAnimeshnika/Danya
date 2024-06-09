using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOrPause : MonoBehaviour
{
    
    int i = 0;
    private void Awake()
    {
        GameObject[] objc = GameObject.FindGameObjectsWithTag("sounds");

        if (objc.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public void PlayMusic()
    {
        GameObject objc = GameObject.FindGameObjectWithTag("music");
        
        
        if (i == 0)
        {
            objc.GetComponent<AudioSource>().volume = 0;
            i = 1;
        }
        else if(i == 1)
        {
            objc.GetComponent<AudioSource>().volume = 0.5f;
            i = 0;
        }    
    }
   
}
