using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public enum DirectionType
{
    Up,Right,Down,Left
}
public class MoveObject : MonoBehaviour
{
    [SerializeField] private Transform containerTF;
    [SerializeField] private Transform launcher;
    [SerializeField] private Transform launchTarget;
    [SerializeField] private Transform getInTarget;
    [SerializeField] private Transform winVFXTarget;
    [SerializeField] private Upper upper;
    [SerializeField] private StaticObject staticObject;
    [SerializeField] private Trigger trigger;
    public TweenData[] tweenDatas;
    public List<Tween> tweenList = new List<Tween>();
    public TweenType currentTweenType;
    public DirectionType directionType;
    public bool isLaunching = false;

    private void Start()
    {
        //OnInit();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UI_HoverTest.Ins.IsPointerOverUIElement())
        {
            if(currentTweenType == TweenType.MoveAround)
            {
                StopTween(currentTweenType);
                SetUpTweenLaunch();
                PlayTween(TweenType.Launch);
                isLaunching = true;
            }
        }
    }

    public void OnInit()
    {
        tweenList.Clear();
        SetUpTweenMoveAround();
    }

    public void SetUpTweenMoveAround()
    {
        Vector3 directionVector = GetSquareVector3(directionType);
        TweenData tweenData = tweenDatas[(int)TweenType.MoveAround];
        Tween tween = Cache.GetTransform(this.gameObject)
            .DOLocalMove(Cache.GetTransform(this.gameObject).localPosition + tweenData.distance * directionVector, tweenData.duration, false)
            .SetEase(tweenData.ease)
            .SetLoops(tweenData.numLoop, tweenData.loopType);
        tweenList.Add(tween);
    }

    public void SetUpTweenLaunch()
    {
        launcher.SetParent(containerTF);
        /*Vector3 directionVector = GetVec3(directionType);
        TweenData tweenData = tweenDatas[(int)TweenType.Launch];
        Tween tween = Cache.GetTransform(launcher.gameObject)
            .DOLocalMove(Cache.GetTransform(launcher.gameObject).localPosition + tweenData.distance * directionVector, tweenData.duration, false)
            .SetEase(tweenData.ease)
            .SetLoops(tweenData.numLoop, tweenData.loopType);
        tweenList.Add(tween);*/

        Vector2 target;
        if (directionType == DirectionType.Down || directionType == DirectionType.Up)
        {
            target = new Vector2(Cache.GetTransform(launcher.gameObject).localPosition.x, launchTarget.localPosition.y);
        }
        else
        {
            target = new Vector2(launchTarget.localPosition.x, Cache.GetTransform(launcher.gameObject).localPosition.y);
        }
        Debug.Log(target);
        TweenData tweenData = tweenDatas[(int)TweenType.Launch];
        Tween tween = Cache.GetTransform(launcher.gameObject)
            .DOLocalMove(target, tweenData.duration, false)
            .SetEase(tweenData.ease)
            .SetLoops(tweenData.numLoop, tweenData.loopType)
            .OnComplete(() =>
            {
                isLaunching = false;
                if (trigger.isWin)
                {
                    OnWin();
                }
                else
                {
                    OnLose();
                }
            });
        tweenList.Add(tween);
    }

    public void SetUpTweenGetIn()
    {
        Vector2 target;
        if (directionType == DirectionType.Down || directionType == DirectionType.Up)
        {
            target = new Vector2(Cache.GetTransform(launcher.gameObject).localPosition.x, getInTarget.localPosition.y);
        }
        else
        {
            target = new Vector2(getInTarget.localPosition.x, Cache.GetTransform(launcher.gameObject).localPosition.y);
        }
        TweenData tweenData = tweenDatas[(int)TweenType.GetIn];
        Tween tween = Cache.GetTransform(launcher.gameObject)
            .DOLocalMove(target, tweenData.duration, false)
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

    public void OnWin()
    {
        WinVFX.Ins.OnInit(winVFXTarget.position);

        //Set up tween GetIn, oncomplete => openUI<Win>
        SetUpTweenGetIn();
        tweenList[(int)TweenType.GetIn].OnComplete(() =>
        {
            if (upper != null)
            {
                upper.ShowSpriteRenderer();
            }
            if (staticObject != null)
            {
                staticObject.OnWin();
            }
            UIManager.Ins.OpenUIAfterSeconds<Win>(1f);
        });
        PlayTween(TweenType.GetIn);

        LeaderboardManager.Ins.OnWin();
        Gameplay.instance.dots[LevelManager.Ins.currentLevelIndex].OnWin();
        
    }

    public void OnLose()
    {
        StopAllTweens();
        Gameplay.instance.OnLose();
        UIManager.Ins.OpenUIAfterSeconds<Lose>(1);
        CameraController.Ins.OnLose();
    }
}
