using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : UICanvas
{
    public Dot[] dots;
    [SerializeField] private RectTransform dotParent;

    //singleton
    public static Gameplay instance;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SlideDots();
        }
    }

    public override void Open()
    {
        base.Open();
        ResetDots();
    }

    public void ResetDots()
    {
        for(int i = 0; i < dots.Length; i++)
        {
            Dot dot = dots[i];
            dot.OnInit();
        }
    }

    public void SlideDots()
    {
        dotParent.DOMove(dotParent.anchoredPosition - new Vector2(5,0), 1f);
    }

}
