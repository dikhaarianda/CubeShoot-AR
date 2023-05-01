using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    public GameObject[] enemy;
    public float SpawnEnemyDuration;
    public float KillEnemyDuration;
    private int currentIndex;
    private float elapsedTime = 0f;
    public bool isEnemyDestroy;

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
    }
}
