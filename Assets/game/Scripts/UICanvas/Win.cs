using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : UICanvas
{
    [SerializeField] private RectTransform completed;
    [SerializeField] private RectTransform buttonNext;
    public Vector3 oldCompletedScale;
    public Vector3 oldButtonScale;


    private void Awake()
    {
        oldCompletedScale = completed.localScale;
        oldButtonScale = buttonNext.localScale;
    }
    
    public override void Open()
    {
        base.Open();
        OnInit();
        EffectOpen();
    }

    public void OnInit()
    {
        completed.localScale = oldCompletedScale;
        buttonNext.localScale = oldButtonScale;
    }

    public void EffectOpen()
    {
        completed
            .DOScale(oldCompletedScale * 1.2f, 0.3f)
            .SetEase(Ease.OutBack);
        buttonNext
            .DOScale(oldButtonScale * 1.2f, 0.3f)
            .SetEase(Ease.OutBack);
    }
}
