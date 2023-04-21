using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    [Header("Game Canvas Panels")]
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject winPanel;
    public GameObject loosePanel;

    public TMP_Text gameScore;
    public TMP_Text winScore;
    public TMP_Text looseScore;

    public void SetUI()
    {
        gamePanel.SetActive(false);
        startPanel.SetActive(true);
    }
    public void OnPlayButtonClicked()
    {
        startPanel.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(true);

        GameManager.Instance.StartGame();
    }

    public void SetLostScreen()
    {
        gamePanel.SetActive(false);
        startPanel.SetActive(false);

        loosePanel.SetActive(true);
    }

    public void SetWinScreen()
    {
        gamePanel.SetActive(false);
        startPanel.SetActive(false);

        winPanel.SetActive(true);
    }

    public void OnRetryClickedHandler()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
