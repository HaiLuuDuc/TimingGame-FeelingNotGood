using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : UICanvas
{
    public List<UserInfoUI> userInfoUIs = new List<UserInfoUI>();
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private Transform frame;
    //singleton
    public static Leaderboard instance;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.D))
        {
            UserInfo userInfo = LeaderboardManager.Ins.userInfos.Find(userInfo => userInfo.name == "Player");
            UserInfoUI userInfoUI = userInfoUIs.Find(userInfoUI => userInfoUI.id == userInfo.id);
            userInfoUI.SwapWithAbove();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            UserInfo userInfo = LeaderboardManager.Ins.userInfos.Find(userInfo => userInfo.name == "Player");
            UserInfoUI userInfoUI = userInfoUIs.Find(userInfoUI => userInfoUI.id == userInfo.id);
            userInfoUI.SwapWithAbove();
        }*/
    }

    public override void Open()
    {
        base.Open();
        DataManager.ins.LoadOldSiblingIndexs(); //sort immediately
        DataManager.ins.CopyNewToOldSiblingIndexs();
        //display old data
        UpdateUserInfoUIs();
        SortUIGradually();
        EffectOpen();
    }

    public void SortUIGradually() 
    {
        Debug.Log("SortUIGradually");
        UserInfo userInfo = LeaderboardManager.Ins.userInfos.Find(userInfo => userInfo.name == "Player");
        UserInfoUI userInfoUI = userInfoUIs.Find(userInfoUI => userInfoUI.id == userInfo.id);
        int moveUpTimes = Cache.GetRectTransform(userInfoUI.gameObject).GetSiblingIndex() - userInfo.rank + 1;
        StartCoroutine(SortUICoroutine(userInfoUI, moveUpTimes));
    }

    public void UpdateUserInfoUIs()
    {
        for(int i=0; i<userInfoUIs.Count; i++)
        {
            userInfoUIs[i].UpdateUI();
        }
    }

    public void EffectOpen()
    {
        Vector3 oldScale = new Vector3(0.3f, 0.3f, 0.3f);
        Vector3 newScale = Vector3.one;

        Cache.GetTransform(frame.gameObject).localScale = oldScale;
        Cache.GetTransform(frame.gameObject)
            .DOScale(newScale, 0.2f)
            .SetEase(Ease.OutBack)
            ;
    }

    public void EffectClose()
    {
        Vector3 oldScale = Vector3.one;
        Vector3 newScale = new Vector3(0.3f, 0.3f, 0.3f);

        Cache.GetTransform(frame.gameObject).localScale = oldScale;
        Cache.GetTransform(frame.gameObject)
            .DOScale(newScale, 0.25f)
            .SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                UIManager.Ins.CloseUI<Leaderboard>();
            })
            ;
    }

    public IEnumerator SortUICoroutine(UserInfoUI userInfoUI, int moveUpTimes)
    {
        yield return new WaitForSeconds(0.3f);
        while (moveUpTimes>0)
        {
            userInfoUI.SwapGradually();
            moveUpTimes--;
            yield return new WaitForSeconds(0.6f);
        }
    }
}
