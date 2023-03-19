using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeathCountAchievement
{
    public int deathCount;
    public int achievementIndex;
}

[System.Serializable]
public class Achievement
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Progress { get; set; }
    public bool IsCompleted { get; set; }
}


/// <summary>
/// Singleton class for managing achievements
/// Dependencies: <c>MessageManager</c>
/// </summary>
public class AchievementManager : MonoBehaviour
{
    // singleton
    public static AchievementManager instance;

    public List<Achievement> achievements;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void UpdateProgress(string achievementName, int progressAmount)
    {
        // Find the achievement by name
        var achievement = achievements.Find(a => a.Name == achievementName);

        if (achievement == null)
        {
            Debug.LogError("Achievement not found: " + achievementName);
            return;
        }

        // Update progress
        achievement.Progress += progressAmount;

        // Check completion
        if (achievement.Progress >= 100 && !achievement.IsCompleted)
        {
            achievement.IsCompleted = true;
            Debug.Log("Achievement completed: " + achievement.Name);
        }
    }

    public int GetDeathCount()
    {
        return PlayerPrefs.GetInt("deaths", 0);
    }

    public bool IsAchievementUnlocked(string name)
    {
        var achievement = achievements.Find(a => a.Name == name);
        if (achievement == null)
        {
            Debug.Log("Achievement is not registered");
            return false;
        }
        var unlocked = PlayerPrefs.GetInt(name,0) == 1;
        return unlocked;
    }
    
     public bool IsAchievementUnlocked(int index)
    {
        var unlocked = PlayerPrefs.GetInt(achievements[index].Name,0) == 1;
        return unlocked;
    }

    public void UnlockAchievement(int index)
    {
        PlayerPrefs.SetInt(achievements[index].Name,1);
    }

    public void UnlockAchievement(string name)
    {
        var achievement = achievements.Find(a => a.Name == name);
        if (achievement == null)
        {
            Debug.Log("Achievement is not registered");
            return;
        }
        PlayerPrefs.SetInt(name,1);
    }


}
