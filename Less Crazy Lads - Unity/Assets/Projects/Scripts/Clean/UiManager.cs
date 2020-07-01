using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager uiManager;
    [SerializeField] private VarStorge varStorge;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Text scoreUi;
    [SerializeField] private Text gameOverScoreUi;
    [SerializeField] private Text gameOverhighScoreUi;

    private void Awake()
    {
        if (uiManager != null && uiManager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            uiManager = this;
        }
        Time.timeScale = 0;
    }
    public void SetTime(float time)
    {
        Time.timeScale = time;
    }
    public void GameOverUIState(bool active)
    {
        gameOverUI.SetActive(active);
    }
    public void AddToScore(int num)
    {
        varStorge.score += num;
        scoreUi.text = "Score :" + varStorge.score;
    }
    public void SetScore(int num)
    {
        varStorge.score = num;
        scoreUi.text = "Score :" + varStorge.score;
    }
    public void UpdateGameOverScoreUi()
    {
        gameOverScoreUi.text = "Score :" + varStorge.score;
    }
    public void CheckForHighscore()
    {
        if(varStorge.score > varStorge.highScore)
        {
            varStorge.highScore = varStorge.score;         
        }
        gameOverhighScoreUi.text = "HighScore :" + varStorge.highScore;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
