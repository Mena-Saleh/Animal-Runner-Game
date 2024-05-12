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

    // Displays game over menu
    public void GameOver()
    {
        gameOverMenu.SetActive(true);
    }
}
