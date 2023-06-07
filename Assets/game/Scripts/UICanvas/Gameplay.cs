using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : UICanvas
{
    [Header("Dots:")]
    [SerializeField] private RectTransform dotParent;
    [SerializeField] private RectTransform initialDotsPosition;
    public Dot[] dots;
    [Header("DarkCover:")]
    [SerializeField] private DarkCover darkCover;


    //singleton
    public static Gameplay instance;
    private void Awake()
    {
        instance = this;
    }

    public override void Open()
    {
        base.Open();
        InitializeDots();
        dots[0].OnProgress();
    }

    public void OnWin()
    {
        SlideDots();
    }

    public void OnLose()
    {
        ShowDarkCover();
    }

    public void InitializeDots()
    {
        dotParent.anchoredPosition = initialDotsPosition.anchoredPosition;
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].OnInit();
        }
    }

    public void SlideDots()
    {
        dotParent.DOAnchorPos(dotParent.anchoredPosition - new Vector2(80,0), 0.5f);
        if (LevelManager.Ins.currentLevelIndex - 1 >= 0)
        {
            dots[LevelManager.Ins.currentLevelIndex-1].TurnSmaller();
        }
        dots[LevelManager.Ins.currentLevelIndex].OnProgress();
    }

    public void ShowDarkCover()
    {
        darkCover.gameObject.SetActive(true);
    }

    public void HideDarkCover()
    {
        darkCover.gameObject.SetActive(false);
    }


}
