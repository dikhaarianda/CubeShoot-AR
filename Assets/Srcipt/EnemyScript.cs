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

    private int currentIndex;
    private float elapsedTime = 0f;

    void Update()
    {
        if (isEnemyDestroy)
        {
            currentIndex = Random.Range(0,enemy.Length);
            enemy[currentIndex].SetActive(true);
            isEnemyDestroy = false;
            elapsedTime = 0f;
        }
        else
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= SpawnEnemyDuration)
            {
                currentIndex = Random.Range(0,enemy.Length);
                enemy[currentIndex].SetActive(true);
                elapsedTime -= SpawnEnemyDuration;
            }

            if (elapsedTime >= KillEnemyDuration)
            {
                enemy[currentIndex].SetActive(false);
            }
        }

        updateScore.text = score.ToString();
    }
}
