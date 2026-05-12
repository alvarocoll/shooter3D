using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIZombie : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    public TMP_InputField inputField;
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        
    }

    void PlayGame()
    {
        string playerName = inputField.text;
        PlayerPrefs.SetString("PlayersName", playerName);
        SceneManager.LoadScene("TopDownShooter");

    }

    void QuitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        
    }
}
