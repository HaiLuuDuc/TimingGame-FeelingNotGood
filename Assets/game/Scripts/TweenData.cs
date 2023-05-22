using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TweenType
{
    MoveAround = 0,
    Launch = 1,
    GetIn = 2
}
[Serializable]
public class TweenData
{
    public TweenType tweenType;
    public float distance;
    public float duration;
    public Ease ease;
    public int numLoop;
    public LoopType loopType;
}
