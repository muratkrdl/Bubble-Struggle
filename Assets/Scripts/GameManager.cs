using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] Image gameOverPanel;
    [SerializeField] Image winPanel;

    void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start() 
    {
        HideGameOverPanel();
        HideWinPanel();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void HideGameOverPanel()
    {
        gameOverPanel.gameObject.SetActive(false);
    }

    public void ShowWinPanel()
    {
        if(winPanel != null)
        {
            winPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void HideWinPanel()
    {
        if(winPanel != null)
            winPanel.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public bool CheckWin()
    {
        var balls = FindObjectsOfType<Ball>();
        foreach (var ball in balls)
        {
            if(ball != null)
            {
                return false;
            }
        }
        return true;
    }

}
