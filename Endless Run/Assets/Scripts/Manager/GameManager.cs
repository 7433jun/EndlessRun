using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator cameraAnimator;

    [SerializeField] GameObject layoutPanel;
    [SerializeField] GameObject countDownNumber;
    int count;

    WaitForSecondsRealtime waitForSecondRealtime = new WaitForSecondsRealtime(1f);

    void Start()
    {
        GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
    }

    public void GameStart()
    {
        cameraAnimator.enabled = true;
        playerAnimator.SetTrigger("Start");

        layoutPanel.SetActive(false);

        StartCoroutine(StartWait());
    }

    IEnumerator StartWait()
    {
        yield return waitForSecondRealtime;
        yield return waitForSecondRealtime;

        StartCoroutine(CountDown());

        yield return waitForSecondRealtime;
        yield return waitForSecondRealtime;
        yield return waitForSecondRealtime;

        playerAnimator.SetLayerWeight(1, 0);
        Time.timeScale = 1.0f;
    }

    IEnumerator CountDown()
    {
        countDownNumber.SetActive(true);

        count = 3;

        while(count > 0)
        {
            countDownNumber.GetComponent<TextMeshProUGUI>().text = count.ToString();
            countDownNumber.GetComponent<Animator>().Play("Count Down");
            yield return waitForSecondRealtime;
            count--;
        }

        countDownNumber.SetActive(false);
    }
}
