using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserInfo
{
    public int id;
    public int rank;
    public CountryType countryType;
    public string name;
    public int passedLevel;
    public float minTotalTime;

    public UserInfo(int id, CountryType countryType, string name, int passedLevel, float minTotalTime) {
        this.id = id;
        this.countryType = countryType;
        this.name = name;
        this.passedLevel = passedLevel;
        this.minTotalTime = minTotalTime;
    }

    public void UpdateInfo(int passedLevel, float minTotalTime)
    {
        this.passedLevel = passedLevel;
        this.minTotalTime = minTotalTime;
    }
}
