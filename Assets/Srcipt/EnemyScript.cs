using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private float SpawnEnemyDuration;
    [SerializeField] private float KillEnemyDuration;
    [SerializeField] private Text updateScore;

    public bool isEnemyDestroy;
    public int score = 0;

    private float elapsedTime = 0f;
    private int currentIndex;
    private int previousIndex;

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
        updateScore.text = score.ToString();
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
}
