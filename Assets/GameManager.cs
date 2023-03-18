using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private float startTime;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        startTime = Time.time;
        uiManager = FindObjectOfType<UIManager>();
        StartCoroutine(TakeTime());
    }

    private IEnumerator TakeTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            var time = Time.time - startTime;
            uiManager.UpdateTime(time);
        }
    }

    public void GameOver()
    {
    }

    public void AddScore(int change)
    {
        score += change;
        uiManager.UpdateScore(score);
    }
}