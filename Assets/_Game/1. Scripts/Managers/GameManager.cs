using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController playerController;
    public UIManager uiManager;


    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        uiManager.SetUI();
        playerController.SetPlayer();
    }
    public void StartGame()
    {
        playerController.GameStart();
    }
    public void LevelLost()
    {
        uiManager.SetLostScreen();
    }
    public void LevelConmplete()
    {
        uiManager.SetWinScreen();
    }

    public void UpdateScore(int score)
    {
        uiManager.gameScore.text = $"Score:  {score.ToString()}";
        uiManager.winScore.text = $"Score:  {score.ToString()}";
        uiManager.looseScore.text = $"Score:  {score.ToString()}";
    }
}
