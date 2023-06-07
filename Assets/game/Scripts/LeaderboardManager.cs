using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            new UserInfo (0, CountryType.Canada, "Player", maxPassedLevel, minTotalTime<9999?minTotalTime:0),
            new UserInfo (1, CountryType.China, "Shou Zhen", 1, 150.2f),
            new UserInfo (2, CountryType.USA, "Mike", 3, 135.6f),
            new UserInfo (3, CountryType.Belgium, "Bruyne", 7, 135.7f),
            new UserInfo (4, CountryType.USA, "Jack", 8, 180.9f)
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

   
    public void OnSkip() // co cong thoi gian vao minTotalTime k?
    {
        Debug.Log("co cong thoi gian vao minTotalTime k?");
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
        SaveMinTotalTime();
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
        SaveMaxPassedLevel();
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
        SaveNewSiblingIndexs();
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
    }

    public void SaveMaxPassedLevel()
    {
        DataManager.ins.playerData.maxPassedLevel = this.maxPassedLevel;
    }

    public void SaveMinTotalTime()
    {
        DataManager.ins.playerData.minTotalTime = this.minTotalTime;
    }

    public void SaveNewSiblingIndexs() {
        for(int i=0;i<userInfos.Count; i++)
        {
            int index = i;
            UserInfo userInfo = userInfos.Find(x => x.id == index);
            DataManager.ins.playerData.newSiblingIndexs[i] = userInfos.IndexOf(userInfo);
        }
    }

}
