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
        yield return new WaitForSecondsRealtime(2f);

        StartCoroutine(CountDown());

        yield return new WaitForSecondsRealtime(3f);

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
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        countDownNumber.SetActive(false);
    }
}
