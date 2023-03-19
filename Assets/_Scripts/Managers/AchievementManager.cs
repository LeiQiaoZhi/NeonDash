using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class DeathCountAchievement
{
    public int deathCount;
    public int achievementIndex;
}

public enum AchievementType {
    Normal, DeathCount, EnemyDefeatCount
}

[System.Serializable]
public class Achievement
{
    public string name;
    public AchievementType type;
    public int target;
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

    public void UpdateDeathCountAchievements(int deaths)
    {
       XLogger.Log(Category.Achievement, $"Updating Death Count Achievements, current deaths -- {deaths}");
        var deathAchievements = achievements.FindAll(a => a.type == AchievementType.DeathCount);
        foreach (var achievement in deathAchievements)
        {
            if (achievement.target <= deaths && !IsAchievementUnlocked(achievement.name))
            {
                UnlockAchievement(achievement.name);   
            }
        }
    }
    
    public int GetDeathCount()
    {
        return PlayerPrefs.GetInt("deaths", 0);
    }

    public bool IsAchievementUnlocked(string achievementName)
    {
        var achievement = achievements.Find(a => a.name == achievementName);
        if (achievement == null)
        {
            Debug.Log("Achievement is not registered");
            return false;
        }
        var unlocked = PlayerPrefs.GetInt(achievementName,0) == 1;
        return unlocked;
    }
    
     public bool IsAchievementUnlocked(int index)
    {
        var unlocked = PlayerPrefs.GetInt(achievements[index].name,0) == 1;
        return unlocked;
    }

    public void UnlockAchievement(int index)
    {
        PlayerPrefs.SetInt(achievements[index].name,1);
        MessageManager.Instance.DisplayMessage($"Achievement unlocked: {achievements[index].name.ToUpper()}");
    }

    public void UnlockAchievement(string achievementName)
    {
        var achievement = achievements.Find(a => a.name == achievementName);
        if (achievement == null)
        {
            Debug.Log("Achievement is not registered");
            return;
        }
        PlayerPrefs.SetInt(achievementName,1);
    }


}
