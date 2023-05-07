using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private string SceneName;
    [SerializeField] private Text HighScoreUI;

    private void Update() {
        HighScoreUI.text = "High Score \n" + PlayerPrefs.GetInt("HighScore");
    }

    public void changeScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}