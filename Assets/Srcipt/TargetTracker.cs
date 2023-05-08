using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetTracker : DefaultObserverEventHandler
{
    [SerializeField] private GameObject PlayerObject;
    [SerializeField] private GameObject StartingUI;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private EnemyScript enemyScript;
    [SerializeField] private Text countdownText;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        StartCoroutine(CountdownCoroutine());
        StartingUI.SetActive(false);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        enemyScript.enabled = false;
        PlayerObject.SetActive(false);
        StartingUI.SetActive(true);
    }

    public void setGameStart()
    {
        StartCoroutine(CountdownCoroutine());
        PauseUI.SetActive(false);
    }

    public void setGameStop()
    {
        enemyScript.enabled = false;
        PlayerObject.SetActive(false);
        PauseUI.SetActive(true);
    }

    IEnumerator CountdownCoroutine()
    {
        int count = 3;

        countdownText.gameObject.SetActive(true);
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
        PlayerObject.SetActive(true);
    }
}