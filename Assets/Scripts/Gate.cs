﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonoBehaviour : UnityEngine.MonoBehaviour
{
    public int currScene = SceneManager.GetActiveScene().buildIndex;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        
        LevelData.NextLevel();
        SceneManager.LoadScene(11);
        

    }
    
 
}
