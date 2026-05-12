using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public Image heart;
    public GameObject endGamePanel;
    public TextMeshProUGUI endGameText;
    public Button backToMenuButton;
    private int _score;

    private void Start()
    {
        backToMenuButton.onClick.AddListener(BackToMenu);
        AddScore(0);
    }

 
    public void AddScore (int score)
    {
        _score += score;

        string playerName = PlayerPrefs.GetString("PlayersName");
        pointsText.text = playerName + " " + _score.ToString();
    }

    public void SetNewLife(float lives)
    {
        float percentage = lives / 3f;
        heart.fillAmount = percentage;
    }

    public void ShowEndGame()
    {
        Time.timeScale = 0f;
        endGamePanel.SetActive(true);
        string playerName = PlayerPrefs.GetString("PlayersName");
        endGameText.text = playerName + " - " + _score.ToString();
    }

    void BackToMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
