using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public Text ammoText;

    public Text healthText;

    public int health = 100;

    public int gunAmmo = 10;

    public int grenades = 3;

    public int selectedWeapon = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ammoText.text = gunAmmo.ToString();
        healthText.text = health.ToString();
    }

    public void LoseHealth(int damage)
    {
        health -= damage;
        CheckHealth();
    }

    public void CheckHealth()
    {
        if (health <= 0)
        {
            //game over
            Debug.Log("Has Muerto");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
