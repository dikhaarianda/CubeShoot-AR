using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetTracker : DefaultObserverEventHandler
{
    [SerializeField] private GameObject HandGun;
    [SerializeField] private GameObject InGameUI;
    [SerializeField] private GameObject StartingUI;
    [SerializeField] private EnemyScript enemyScript;
    [SerializeField] private Text countdownText;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        StartCoroutine(CountdownCoroutine());
        countdownText.gameObject.SetActive(true);
        StartingUI.SetActive(false);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        enemyScript.enabled = false;
        HandGun.SetActive(false);
        InGameUI.SetActive(false);
        StartingUI.SetActive(true);
    }

    IEnumerator CountdownCoroutine()
    {
        int count = 3;

        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1);

        countdownText.gameObject.SetActive(false);
        enemyScript.enabled = true;
        HandGun.SetActive(true);
        InGameUI.SetActive(true);
    }
}
