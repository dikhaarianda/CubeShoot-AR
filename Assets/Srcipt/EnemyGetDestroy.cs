using UnityEngine;

public class EnemyGetDestroy : MonoBehaviour
{
    private EnemyScript enemyScript;

    private void Start() {
        enemyScript = FindObjectOfType<EnemyScript>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyScript.isEnemyDestroy = true;
            gameObject.SetActive(false);
        }
    }
}
