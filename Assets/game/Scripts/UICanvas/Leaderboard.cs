using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
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

    public override void Open()
    {
        base.Open();
        SortUI();
        UpdateUserInfoUI();
        EffectOpen();
    }

    public void SortUI() 
    {
        for(int i=0;i<userInfoUIs.Count; i++)
        {
            int index = LeaderboardManager.Ins.userInfos.Find(userinfo => userinfo.id == userInfoUIs[i].id).rank - 1;
            Cache.GetRectTransform(userInfoUIs[i].gameObject).SetSiblingIndex(index);
        }

        /*gridLayoutGroup.SetLayoutHorizontal();
        gridLayoutGroup.SetLayoutVertical();*/
    }

    public void UpdateUserInfoUI()
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
}
