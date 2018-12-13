using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text scoreText;
    public Text healthText;
    public int playerHealth = 100;
    public Image healthImage;

    private int score;

    // Use this for initialization
    void Start()
    {
        score = 0;
        UpdateScore();
        UpdateHealth();
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void TookDamage(int damageValue)
    {
        playerHealth -= damageValue;
        healthImage.rectTransform.sizeDelta = new Vector2(playerHealth * 4, 123.2f);
        healthImage.transform.position = new Vector2(healthImage.transform.position.x - 18, healthImage.transform.position.y);
        UpdateHealth();
    }
    void UpdateHealth()
    {
        healthText.text = "Health: " + playerHealth;
    }
    
}