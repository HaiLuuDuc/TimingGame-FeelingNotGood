using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Move move;
    [SerializeField] private Upper upper;
    public bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.DEATH_ZONE) && isTriggered==false)
        {
            move.StopAllTweens();
            Gameplay.instance.dots[LevelManager.Ins.currentLevelIndex].OnLose();
            LevelManager.Ins.LoadNextLevel();
            isTriggered = true;
        }

        if (collision.CompareTag(Constant.WIN_ZONE) && isTriggered == false)
        {
            move.SetUpTweenFromTweenData(TweenType.GetIn);
            move.tweenList[(int)TweenType.GetIn].OnComplete(() =>
                {
                    if (upper != null)
                    {
                        upper.ShowSpriteRenderer();
                    }
                    LevelManager.Ins.LoadNextLevel();
                });
            move.PlayTween(TweenType.GetIn);
            LeaderboardManager.Ins.OnWin();
            Gameplay.instance.dots[LevelManager.Ins.currentLevelIndex].OnWin();
            isTriggered = true;
        }
    }
}
