using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Animator playerAnimator;

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
        playerAnimator.SetLayerWeight(1, 0);
        Time.timeScale = 1.0f;
    }
}
