using UnityEngine;

public class EnemyGetDestroy : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    private EnemyScript enemyScript;

    private void Start() {
        enemyScript = FindObjectOfType<EnemyScript>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyScript.isEnemyDestroy = true;
            enemyScript.score++;
            enemyScript.EnemyDestroy.Play();

            gameObject.SetActive(false);
            Instantiate(effect, transform.position,Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
