using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject difficulty;
    [SerializeField] GameObject main;

  public void NewGameClick()
    {
        Dif.difMul = 1;
        difficulty.SetActive(true);
        main.SetActive(false);
    }

    public void BackToMenu()
    {
        difficulty.SetActive(false);
        main.SetActive(true);
    }


    public void ExitClick()
    {
        Application.Quit();
    }
}
