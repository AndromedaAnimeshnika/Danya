using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Dif : MonoBehaviour
{
    public static int difMul=1;
  
    public void Easy()
    {
        difMul*=1;
        
        SceneManager.LoadScene(1);
    }
    public void Medium()
    {
        difMul *= 2;
      
        SceneManager.LoadScene(1);
    }
    public void Hard()
    {

        difMul *= 3;
       
        SceneManager.LoadScene(1);
    }
}
