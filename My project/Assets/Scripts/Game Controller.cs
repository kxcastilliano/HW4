using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public TextMeshProUGUI pointText;
    public AudioSource pointSound;
    private int score = 0;
    public TextMeshProUGUI gameover;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
       
    }
    public  void Start()
    {
       
        gameover.enabled = false;
    }
    void OnEnable()
        { Points.OnScorePoint += Addpoint;
            Player.OnPlayerDied += GameOver;
      
        }

        void OnDisable()
        { Points.OnScorePoint -= Addpoint;
            Player.OnPlayerDied -= GameOver;
        }
     
       
     
    

    public void Addpoint()
    {
       score++;
       pointText.text = score.ToString();
        pointSound.Play();
    }

    public void GameOver()
    {
        gameover.enabled = true; 
        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }
}