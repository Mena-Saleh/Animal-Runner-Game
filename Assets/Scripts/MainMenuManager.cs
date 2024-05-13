using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private GameData gameData;

    public Text uiCoins;
    public Text uiDistance;
    private void Awake()
    {
        gameData = SaveSystem.Load();
        RefreshUI();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void RefreshUI()
    {
        uiCoins.text = gameData.totalCoins.ToString() + " x";
        uiDistance.text = "HighScore: " + gameData.distanceHighscore.ToString() + " m";
    }
}
