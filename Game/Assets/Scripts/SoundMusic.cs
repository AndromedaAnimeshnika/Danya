using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMusic : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objc = GameObject.FindGameObjectsWithTag("music");

        if (objc.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


  


}
