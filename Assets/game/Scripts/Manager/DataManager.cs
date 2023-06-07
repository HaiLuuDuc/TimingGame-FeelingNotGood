using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEngine.UI;
using JetBrains.Annotations;


public class DataManager : MonoBehaviour
{
    public static DataManager ins;
    private void Awake()
    {
        ins = this;
    }
    private void Start()
    {
        this.LoadData();
    }
    public bool isLoaded = false;
    public PlayerData playerData;
    public const string PLAYER_DATA = "PLAYER_DATA";


    private void OnApplicationPause(bool pause) { SaveData(); }
    private void OnApplicationQuit() { SaveData(); }


    public void LoadData()
    {
        string d = PlayerPrefs.GetString(PLAYER_DATA, "");
        if (d != "")
        {
            playerData = JsonUtility.FromJson<PlayerData>(d);
        }
        else
        {
            playerData = new PlayerData();
        }

        LoadMaxPassedLevel();
        LoadMinTotalTime();

        // sau khi hoàn thành tất cả các bước load data ở trên
        isLoaded = true;
    }

    public void SaveData()
    {
        if (!isLoaded) return;
        string json = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString(PLAYER_DATA, json);
    }

    public void LoadMaxPassedLevel()
    {
        LeaderboardManager.Ins.maxPassedLevel = playerData.maxPassedLevel;
    }

    public void LoadMinTotalTime()
    {
        LeaderboardManager.Ins.minTotalTime = playerData.minTotalTime;
    }

    public void LoadOldSiblingIndexs()
    {
        Debug.Log("LoadOldSiblingIndexs");
        for(int i=0;i<playerData.oldSiblingIndexs.Length;i++)
        {
            int index = i;
            UserInfoUI userInfoUI = Leaderboard.instance.userInfoUIs.Find(x => x.id == index);
            Cache.GetRectTransform(userInfoUI.gameObject).SetSiblingIndex(playerData.oldSiblingIndexs[i]);
        }
    }

    public void CopyNewToOldSiblingIndexs()
    {
        for(int i = 0; i < 5; i++)
        {
            playerData.oldSiblingIndexs[i] = playerData.newSiblingIndexs[i];
        }
    }

}


[System.Serializable]
public class PlayerData
{
    /*[Header("--------- Game Setting ---------")]
    public bool isNew = true;
    public bool isMusic = true;
    public bool isSound = true;
    public bool isVibrate = true;
    public bool isNoAds = false;
    public int starRate = -1;*/


    [Header("--------- Game Params ---------")]
    public bool isSetUp = false;
    public int maxPassedLevel;
    public float minTotalTime;
    public int[] oldSiblingIndexs = new int[5];
    public int[] newSiblingIndexs = new int[5];

    public PlayerData()
    {
        maxPassedLevel = 0;
        minTotalTime = 9999;
        oldSiblingIndexs[0] = 4;
        oldSiblingIndexs[1] = 3;
        oldSiblingIndexs[2] = 2;
        oldSiblingIndexs[3] = 1;
        oldSiblingIndexs[4] = 0;
        isSetUp = true;
    }
}