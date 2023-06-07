using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSkip : BaseButton
{
    protected override void OnClick()
    {
        if (LevelManager.Ins.currentLevel.isLaunched == true)
        {
            return;
        }
        else
        {
            StartCoroutine(Skip());
        }
    }

    public IEnumerator Skip()
    {
        UIManager.Ins.OpenUI<Ads>();
        yield return StartCoroutine(Ads.instance.CloseAfter(2f));
        Gameplay.instance.dots[LevelManager.Ins.currentLevelIndex].OnWin();
        LevelManager.Ins.DestroyCurrentLevel();
        LevelManager.Ins.LoadNextLevel();
        LeaderboardManager.Ins.OnSkip();
        WinVFX.Ins.OnDestroy();
        yield return null;
    }

    public void OnPointerEnter()
    {
        Debug.Log("enter");
    }

    public void OnPointerExit()
    {
        Debug.Log("exit");
    }

}
