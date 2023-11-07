using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public float speed = 15f;

    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator cameraAnimator;

    [SerializeField] GameObject layoutPanel;
    [SerializeField] GameObject countDownNumber;
    [SerializeField] GameObject gameOverPanel;
    int count;

    WaitForSecondsRealtime waitForSecondRealtime = new WaitForSecondsRealtime(1f);

    void Start()
    {
        Time.timeScale = 0.0f;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void TimeStop()
    {
        Time.timeScale = 0.0f;
    }

    public void TimeContinue()
    {
        Time.timeScale = 1.0f;
    }

    public void GameStart()
    {
        cameraAnimator.enabled = true;
        playerAnimator.SetTrigger("Start");

        layoutPanel.SetActive(false);

        StartCoroutine(StartWait());
    }

    public void Retry()
    {
        // SceneManager.GetActiveScene().name 현재 씬의 이름
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            yield return waitForSecondRealtime;
            count--;
        }

        countDownNumber.SetActive(false);
    }
}
