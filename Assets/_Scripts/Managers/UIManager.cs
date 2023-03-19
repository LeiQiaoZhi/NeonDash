using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject levelEndScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI meterText;

    private void Awake()
    {
        SetEnableGameOverScreen(false);
        SetEnableLevelEndScreen(false);
    }

    public void SetEnableGameOverScreen(bool enable)
    {
        gameOverScreen.SetActive(enable);
    }

    public void SetEnableLevelEndScreen(bool enable)
    {
        levelEndScreen.SetActive(enable);
    }

    public void DisplayAchievementUnlockMessage(int i)
    {
        AchievementManager achievementManager = AchievementManager.instance;
        if (achievementManager.IsAchievementUnlocked(i))
        {
            XLogger.Log(Category.Achievement,$"Achivement {achievementManager.achievements[i].Name} is already unlocked");
            return;
        }
        achievementManager.UnlockAchievement(i);
        MessageManager.Instance.DisplayMessage($"Achievement Unlock: {achievementManager.achievements[i].Name.ToUpper()}");
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void UpdateTime(float time)
    {
        timeText.text = $"{Math.Round(time,1):F1}s";
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateMeters(float meters)
    {
        meterText.text = $"{meters:F1}m";
    }

}
