using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject ImageTarget;

    [SerializeField] private float SpawnEnemyDuration;
    [SerializeField] private float KillEnemyDuration;
    [SerializeField] private Text updateScore;
    [SerializeField] private Text timeText;
    [SerializeField] private Text ScoreUI;

    private float elapsedTime;
    private float gamePlayTime;

    private int currentIndex;
    private int previousIndex;
    private int highScore;

    public AudioSource EnemyDestroy;
    public int score;
    public bool isEnemyDestroy;

    private void Start() {
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    private void Update()
    {
        if (isEnemyDestroy)
        {
            randomGenerator();
            isEnemyDestroy = false;
            elapsedTime = 0f;
        }
        else
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= SpawnEnemyDuration)
            {
                randomGenerator();
                elapsedTime -= SpawnEnemyDuration;
            }

            if (elapsedTime >= KillEnemyDuration)
            {
                enemy[currentIndex].SetActive(false);
            }
        }

        gamePlayTime += Time.deltaTime;
        if (gamePlayTime >= 60f)
        {
            ScoreUI.text = "Your Score \n" + score.ToString();
            if (score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            GameOverUI.SetActive(true);
            ImageTarget.SetActive(false);
        }
        UpdateTimeText();
        updateScore.text = "Score: \n" + score.ToString();
    }

    private void randomGenerator()
    {
        currentIndex = Random.Range(0,enemy.Length);

        while (currentIndex == previousIndex)
        {
            currentIndex = Random.Range(0,enemy.Length);
        }

        enemy[currentIndex].SetActive(true);
        previousIndex = currentIndex;
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(gamePlayTime / 60f);
        int seconds = Mathf.FloorToInt(gamePlayTime % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timeText.text = timeString;
    }
}