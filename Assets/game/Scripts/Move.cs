using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public enum DirectionType
{
    Up,Right,Down,Left
}
public class Move : MonoBehaviour
{
    public TweenData[] tweenDatas;
    public List<Tween> tweenList = new List<Tween>();
    public TweenType currentTweenType;
    public DirectionType directionType;

    private void Start()
    {
    }

    public void OnInit()
    {
        tweenList.Clear();
        SetUpTweenFromTweenData(TweenType.MoveAround);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if(currentTweenType == TweenType.MoveAround)
            {
                StopTween(currentTweenType);
                SetUpTweenFromTweenData(TweenType.Launch);
                PlayTween(TweenType.Launch);
            }
        }
    }

    public void SetUpTweenFromTweenData(TweenType tweenType)
    {
        Vector3 directionVector = tweenType == TweenType.MoveAround? GetSquareVector3(directionType) : GetVec3(directionType);
        TweenData tweenData = tweenDatas[(int)tweenType];
        Tween tween = Cache.GetTransform(this.gameObject)
            .DOLocalMove(Cache.GetTransform(this.gameObject).position + tweenData.distance * directionVector, tweenData.duration, false)
            .SetEase(tweenData.ease)
            .SetLoops(tweenData.numLoop, tweenData.loopType);
        tweenList.Add(tween);
    }

    public void PlayTween(TweenType newTweenType)
    {

        if(GetTween(currentTweenType) != null)
        {
            StopTween(currentTweenType);
        }

        if (GetTween(newTweenType) != null)
        {
            GetTween(newTweenType).Play(); // Play the tween from the paused state
        }
        
        currentTweenType = newTweenType;
    }

    public void StopTween(TweenType tweenType)
    {
        if (GetTween(tweenType) != null && GetTween(tweenType).IsPlaying())
        {
            GetTween(tweenType).Pause(); // Pause the tween if it is currently playing
        }
    }

    public void StopAllTweens()
    {
        for(int i=0;i<tweenList.Count;i++)
        {
            if (tweenList[i] != null)
            {
                tweenList[i].Pause();
            }
        }
    }

    public Tween GetTween(TweenType tweenType)
    {
        return tweenList[(int)tweenType];
    }

    public Vector3 GetVec3(DirectionType directionType)
    {
        switch (directionType)
        {
            case DirectionType.Up: return Vector3.up;
            case DirectionType.Right: return Vector3.right;
            case DirectionType.Down: return Vector3.down;
            case DirectionType.Left: return Vector3.left;
            default:  return Vector3.zero;
        }
    }

    public Vector3 GetSquareVector3(DirectionType directionType)
    {
        if (directionType == DirectionType.Left)
        {
            return Vector3.down;
        }
        else if(directionType == DirectionType.Up)
        {
            return Vector3.right;
        }
        else if (directionType == DirectionType.Down)
        {
            return Vector3.right;
        }
        else if (directionType == DirectionType.Right)
        {
            return Vector3.down;
        }
        return Vector3.zero;
    }

}
