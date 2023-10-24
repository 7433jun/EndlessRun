using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator cameraAnimator;

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

        StartCoroutine(StartWait());

        //playerAnimator.SetLayerWeight(1, 0);
        //Time.timeScale = 1.0f;
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        Debug.Log("A");
        yield return new WaitForSecondsRealtime(playerAnimator.GetCurrentAnimatorStateInfo(1).length);
        Debug.Log("B");
        playerAnimator.SetLayerWeight(1, 0);
        Time.timeScale = 1.0f;
    }
}
