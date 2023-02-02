using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject defenderOBJ;
    public DefenderController defender;
    public GameObject targetOBJ;
    public TargetController target;

    public bool healthDrain = true;
    public int drainNum = 10;

    public Text scoreText;
    public float score = 0;
    public int scoreInt;
    public bool startTimer = false;

    public bool respawn = false;
    public float timer = 0f;
    public float respawnTime = 15f;


    void Update()
    {
        scoreText.text = scoreInt.ToString();

        if (startTimer == true)
        {
            score += Time.deltaTime;
            scoreInt = Mathf.RoundToInt(score);
        }

        if (respawn == true)
        {
            timer += Time.deltaTime;
            if (timer >= respawnTime)
            {
                timer = 0f;
                defender.currentHealth = defender.maxHealth;
                defenderOBJ.SetActive(true);
                defender.transform.position = target.currentPos;
                respawn = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (healthDrain == true)
        {
            defender.currentHealth -= drainNum * Time.deltaTime;
        }
    }
}