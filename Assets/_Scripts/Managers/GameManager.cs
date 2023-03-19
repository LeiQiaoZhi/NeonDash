using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject meterPrefab;
    
    private UIManager uiManager;
    private float startTime;
    private int score;
    private GameObject player;
    private float meters;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>().gameObject;
        startTime = Time.time;
        uiManager = FindObjectOfType<UIManager>();
        StartCoroutine(TakeTime());
        CreatePastMeters();
    }

    private void CreatePastMeters()
    {
        var deaths = PlayerPrefs.GetFloat("deaths", 0);
        for (int i = 0; i < deaths; i++)
        {
            var meterObject = Instantiate(meterPrefab);
            var meter = PlayerPrefs.GetFloat($"meter-{i}", -100);
            if (meter > -100)
            {
                meterObject.GetComponent<MeterObject>().alpha = Mathf.Lerp(0.1f, 1f, (i+1) / deaths);
                meterObject.transform.position = new Vector3(0,meter,0);
                meterObject.GetComponentInChildren<TextMeshProUGUI>().text = $"Deaths {i} -- {meter:F1}m";
            }
        }
    }

    private IEnumerator TakeTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            var time = Time.time - startTime;
            uiManager.UpdateTime(time);
            meters = player.transform.position.y;
            uiManager.UpdateMeters(meters);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        uiManager.SetEnableGameOverScreen(true);
        // increase death count
        var deaths = PlayerPrefs.GetFloat("deaths", 0);
        deaths++;
        PlayerPrefs.SetFloat("deaths",deaths);
        // record meters
        PlayerPrefs.SetFloat($"meter-{deaths}",meters);
    }

    public void AddScore(int maxHealth)
    {
        score += maxHealth;
        uiManager.UpdateScore(score);
    }
}