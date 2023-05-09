using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Vuforia;

public class TargetTracker : DefaultObserverEventHandler
{
    [SerializeField] private GameObject PlayerObject;
    [SerializeField] private GameObject StartingUI;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private EnemyScript enemyScript;
    [SerializeField] private ImageTargetBehaviour imageTarget;
    [SerializeField] private Text countdownText;
    [SerializeField] private Text scoreUI;
    private bool isTracking;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        StartCoroutine(CountdownCoroutine());
        StartingUI.SetActive(false);
        isTracking = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        enemyScript.enabled = false;
        PlayerObject.SetActive(false);
        StartingUI.SetActive(true);
        isTracking = false;
    }

    public void setGameStart()
    {
        PauseUI.SetActive(false);
        imageTarget.enabled = true;
        Time.timeScale = 1;
        if (isTracking)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    public void setGameStop()
    {
        scoreUI.text = "Your Score \n" + enemyScript.score.ToString();
        PlayerObject.SetActive(false);
        PauseUI.SetActive(true);
        imageTarget.enabled = false;
        Time.timeScale = 0;
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