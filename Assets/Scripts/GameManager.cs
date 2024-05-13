using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public Text uiDistance;

    public Text uiCoins;

    private int collectedCoins = 0;

    public GameObject gameOverMenu;

    public GameData gameData;

    void Awake()
    {
        gameData = SaveSystem.Load();
    }
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.RoundToInt(player.transform.position.z);
        uiDistance.text = distance.ToString() + " m";
        uiCoins.text = collectedCoins.ToString() + " x";

    }

    // Adds one collected coin
    public void AddCoin()
    {
        collectedCoins++;
    }

    // Saves game info + shows game over menu
    public void GameOver()
    {
        // Save collected coins
        gameData.totalCoins += collectedCoins;

        // Getting distance covered and comparing it to highscore
        int coveredDistance = Mathf.RoundToInt(player.transform.position.z);
        gameData.distanceHighscore = Math.Max(gameData.distanceHighscore, coveredDistance);

        // Saving data
        SaveSystem.Save(gameData);

        // Showing game over menu
        gameOverMenu.SetActive(true);
    }
}
