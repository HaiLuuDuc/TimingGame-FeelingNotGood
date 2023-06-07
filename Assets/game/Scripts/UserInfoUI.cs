using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInfoUI : MonoBehaviour
{
    public int id;
    public Image medal;
    public Image country;
    public TextMeshProUGUI name;
    public TextMeshProUGUI passedLevel;
    public TextMeshProUGUI minTotalTime;

    public void UpdateUI()
    {
        UserInfo userinfo = LeaderboardManager.Ins.userInfos.Find(userinfo => userinfo.id == this.id);
        medal.sprite = LeaderboardManager.Ins.medals[userinfo.rank - 1];
        country.sprite = LeaderboardManager.Ins.countries[(int)userinfo.countryType];
        name.text = userinfo.name;
        passedLevel.text = "Lv: " + userinfo.passedLevel.ToString();
        UpdateTime(userinfo.minTotalTime);
    }

    public void UpdateTime(float time)
    {
        int minute = (int)time / 60;
        int second = (int)time % 60;
        int milisecond = (int)(time * 100 % 100 / 100 * 60);

        string minuteString = "";
        string secondString = "";
        string milisecondString = "";

        if (minute < 10)
        {
            minuteString = "0" + minute.ToString();
        }
        else
        {
            minuteString = minute.ToString();
        }

        if (second < 10)
        {
            secondString = "0" + second.ToString();
        }
        else
        {
            secondString = second.ToString();
        }

        if (milisecond < 10)
        {
            milisecondString = "0" + milisecond.ToString();
        }
        else
        {
            milisecondString = milisecond.ToString();
        }

        minTotalTime.text = minuteString + ":" + secondString + ":" + milisecondString;

    }
    
   /* public void SwapImmediately()
    {
        int currentSiblingIndex = Cache.GetRectTransform(this.gameObject).GetSiblingIndex();
        if (currentSiblingIndex == 0)
        {
            return;
        }
        else
        {
            int newSiblingIndex = currentSiblingIndex - 1;
            UserInfoUI userInfoUI = Leaderboard.instance.userInfoUIs
                .Find(userInfoUI => Cache.GetRectTransform(userInfoUI.gameObject).GetSiblingIndex() == newSiblingIndex);
            RectTransform target = Cache.GetRectTransform(userInfoUI.gameObject);
            Cache.GetRectTransform(this.gameObject)
                .DOAnchorPos(target.anchoredPosition, 0.5f)
                .SetEase(Ease.InOutSine)
                .OnComplete(() =>
                {
                    Cache.GetRectTransform(this.gameObject).SetSiblingIndex(newSiblingIndex);
                })
                ;
            Cache.GetRectTransform(userInfoUI.gameObject)
                .DOAnchorPos(Cache.GetRectTransform(this.gameObject).anchoredPosition, 0.5f)
                .SetEase(Ease.InOutSine)
                .OnComplete(() =>
                {
                    Cache.GetRectTransform(userInfoUI.gameObject).SetSiblingIndex(currentSiblingIndex);
                })
                ;
        }
    }*/

    public void SwapGradually()
    {
        int currentSiblingIndex = Cache.GetRectTransform(this.gameObject).GetSiblingIndex();
        if (currentSiblingIndex == 0)
        {
            return;
        }
        else
        {
            int newSiblingIndex = currentSiblingIndex - 1;
            UserInfoUI userInfoUI = Leaderboard.instance.userInfoUIs
                .Find(userInfoUI => Cache.GetRectTransform(userInfoUI.gameObject).GetSiblingIndex() == newSiblingIndex);
            RectTransform target = Cache.GetRectTransform(userInfoUI.gameObject);
            Cache.GetRectTransform(this.gameObject)
                .DOAnchorPos(target.anchoredPosition, 0.5f)
                .SetEase(Ease.InOutSine)
                .OnComplete(() =>
                {
                    Cache.GetRectTransform(this.gameObject).SetSiblingIndex(newSiblingIndex);
                })
                ;
            Cache.GetRectTransform(userInfoUI.gameObject)
                .DOAnchorPos(Cache.GetRectTransform(this.gameObject).anchoredPosition, 0.5f)
                .SetEase(Ease.InOutSine)
                .OnComplete(() =>
                {
                    Cache.GetRectTransform(userInfoUI.gameObject).SetSiblingIndex(currentSiblingIndex);
                })
                ;
        }
    }



    /*public void MoveDown()
    {
        currentSiblingIndex = Cache.GetRectTransform(this.gameObject).GetSiblingIndex();
        if (currentSiblingIndex == Leaderboard.instance.userInfoUIs.Count-1)
        {
            return;
        }
        else
        {
            int newSiblingIndex = currentSiblingIndex + 1;
            UserInfoUI userInfoUI = Leaderboard.instance.userInfoUIs
                .Find(userInfoUI => Cache.GetRectTransform(userInfoUI.gameObject).GetSiblingIndex() == newSiblingIndex);
            RectTransform target = Cache.GetRectTransform(userInfoUI.gameObject);
            Cache.GetRectTransform(this.gameObject)
                .DOAnchorPos(target.anchoredPosition, 0.5f)
                .SetEase(Ease.InOutSine)
                .OnComplete(() =>
                {
                    Cache.GetRectTransform(this.gameObject).SetSiblingIndex(newSiblingIndex);
                })
                ;
            Cache.GetRectTransform(userInfoUI.gameObject)
                .DOAnchorPos(Cache.GetRectTransform(this.gameObject).anchoredPosition, 0.5f)
                .SetEase(Ease.InOutSine)
                .OnComplete(() =>
                {
                    Cache.GetRectTransform(userInfoUI.gameObject).SetSiblingIndex(currentSiblingIndex);
                })
                ;
        }
    }*/

}
