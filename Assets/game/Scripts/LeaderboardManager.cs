using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CountryType
{
    Canada, Bangladesh, Belgium, China, USA
}
public class LeaderboardManager : Singleton<LeaderboardManager>
{
    [Header("Level:")]
    public int maxPassedLevel = 0;
    public int currentPassedLevel = 0;
    [Header("Time:")]
    public float minTotalTime = 9999f;
    public float currentTotalTime = 0f;
    [Header("Medal:")]
    public Sprite[] medals;
    [Header("Country:")]
    public Sprite[] countries;
    [Header("User:")]
    public List<UserInfo> userInfos; 

    private void Start()
    {
        userInfos = new List<UserInfo>
        {
            new UserInfo (0, CountryType.Canada, "Player", 0, 0f ),
            new UserInfo (1, (CountryType)Random.Range(0,countries.Length), "Fake User 1", 1, 150.2f),
            new UserInfo (2, (CountryType)Random.Range(0, countries.Length), "Fake User 2", 3, 135.6f),
            new UserInfo (3, (CountryType)Random.Range(0, countries.Length), "Fake User 3", 7, 135.7f),
            new UserInfo (4, (CountryType)Random.Range(0, countries.Length), "Fake User 4", 8, 180.9f)
        };

        SortLeaderboard();
    }

    public void OnWin()
    {
        UpdateCurrentTotalTime(Timer.Ins.timer);
        UpdateCurrentPassedLevel();
        UpdateMinTotalTime();
        UpdateMaxPassedLevel();
        UpdateUserInfo("Player", maxPassedLevel, minTotalTime);
        SortLeaderboard();
    }

   
    public void OnSkip()
    {
        UpdateMinTotalTime();
        UpdateCurrentPassedLevel();
        UpdateMaxPassedLevel();
        UpdateUserInfo("Player", maxPassedLevel, minTotalTime);
        SortLeaderboard();
    }

    //total time
    public void UpdateCurrentTotalTime(float levelTime)
    {
        currentTotalTime += levelTime;
    }

    public void UpdateMinTotalTime()
    {
        if(currentPassedLevel > maxPassedLevel)
        {
            minTotalTime = currentTotalTime;
        }
        else if(currentPassedLevel == maxPassedLevel)
        {
            minTotalTime = currentTotalTime < minTotalTime ? currentTotalTime : minTotalTime;
        }
    }

    public void ResetCurrentTotalTime()
    {
        currentTotalTime = 0f;
    }

    //passed level
    public void UpdateCurrentPassedLevel()
    {
        currentPassedLevel++;
    }

    public void UpdateMaxPassedLevel()
    {
        maxPassedLevel = currentPassedLevel > maxPassedLevel ? currentPassedLevel : maxPassedLevel;
    }

    public void ResetCurrentPassedLevel()
    {
        currentPassedLevel = 0;
    }

    //sort
    private void SortLeaderboard()
    {
        //sort level
        userInfos.Sort((x, y) => y.passedLevel.CompareTo(x.passedLevel));
        //sort time
        userInfos.Sort((x, y) =>
        {
            int levelComparison = y.passedLevel.CompareTo(x.passedLevel);
            //lv != lv
            if (levelComparison != 0)
            {
                return levelComparison;
            }
            //lv == lv
            else
            {
                return x.minTotalTime.CompareTo(y.minTotalTime);
            }
        });
        UpdateRank();
    }

    private void UpdateRank()
    {
        for (int i = 0; i < userInfos.Count; i++)
        {
            userInfos[i].rank = i+1;
        }
    }

    public void AddUser(UserInfo userInfo)
    {
        userInfos.Add(userInfo);
        SortLeaderboard();
        UpdateRank();
    }

    public void UpdateUserInfo(string userName, int passedLevel, float minTotalTime)
    {
        UserInfo userInfo = userInfos.Find(userInfo => userInfo.name == userName);
        userInfo.UpdateInfo(passedLevel, minTotalTime);
        UpdateRank();
    }

}
