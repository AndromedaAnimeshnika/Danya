using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    [SerializeField] Text txtStatistic, txtFinish;
    [SerializeField] Player player;
    [SerializeField] Transform basePlayerTransform;
    [SerializeField] BasePlayer basePlayer;
    
    [SerializeField] GameObject meteorite, enemy, menuPause, menuFinish;
    [SerializeField] int baseHP, playerHP, countEnemys, countMeteorites;
    GameObject[] enemys;
    public AudioSource engine;





    int getCountEnemy()
    {
        int count = 0;
        foreach(GameObject g in enemys) 
        { 
            if(g!=null)
            {
                count++;
            }
        }
        return count;
    }
    private void Start()
    {
        countEnemys *= Dif.difMul;
        GenerateLevel();
        player.hp = playerHP;
        basePlayer.hp = baseHP;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        
        

    }
    private void Update()
    {
        txtStatistic.text = $"✈️{player.hp,3}\n❤️{basePlayer.hp,3}\n☠️{getCountEnemy(),3}";
        if(basePlayer.hp <= 0||player.hp ==0)
        {
            Lose();
           
            return;
        }
        if(getCountEnemy()==0)
        {
            Win();
            
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape)&&Time.timeScale == 1)
        {
            PauseGame();
        }
    }

    void GenerateLevel() 
    {
        enemys = new GameObject[countEnemys];
        for(int i = 0; i < countEnemys; i++)
        {
            Vector3 randomPos = UnityEngine.Random.onUnitSphere * 150;
            enemys[i] = Instantiate(enemy, randomPos, Quaternion.identity);
            Enemy script = enemys[i].GetComponent<Enemy>();
            script.target = basePlayerTransform;
        }
        for(int i = 0;  i < countMeteorites;i++)
        {
            Vector3 randomPos = UnityEngine.Random.onUnitSphere * 50;
            Instantiate(meteorite, randomPos, Quaternion.identity);
        }
    }
    void Lose() 
    {
        menuFinish.SetActive(true);
        txtFinish.text = "Поражение";
        engine.Stop();
        Time.timeScale = 0;
        Cursor.lockState= CursorLockMode.None;
    }
    void Win() 
    {
        menuFinish.SetActive(true);
        txtFinish.text = "Победа";
        engine.Stop();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
    void PauseGame()
    {
        menuPause.SetActive(true);
        engine.Stop();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
    public void ContinueGame() 
    {
        menuPause.SetActive(false);
        engine.Play();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void RestartGame() 
    {
        SceneManager.LoadScene(1);
    }
    public void Exit() 
    {
        SceneManager.LoadScene(0);
    }

}
